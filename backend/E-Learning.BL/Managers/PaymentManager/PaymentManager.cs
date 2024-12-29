using E_Learning.BL.DTO.Payment;
using E_Learning.BL.Enums;
using E_Learning.BL.Managers.CourseManager;
using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace E_Learning.BL.Managers.PaymentManager
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseManager _courseManager;
        private OrderRegisterationDTO? OrderReguest;
        private PaymentKeyRequestDTO? PaymentKeyRequest;

        public PaymentManager(IConfiguration configuration, IUnitOfWork unitOfWork, ICourseManager courseManager)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _courseManager = courseManager;
        }

        /*------------------------------------------ Payment Methods -------------------------------------------*/
        // 1- Online Card
        public async Task<BasePaymentResponseDTO<string>> GetOnlineCardIFrame(int userId)
        {
            var OnlineCardIFrameResponse = new BasePaymentResponseDTO<string>();

            string IFrame = "https://accept.paymob.com/api/acceptance/iframes/817634?payment_token=";

            var price = _unitOfWork.CartRepository.GetCartTotalByUserId(userId);

            try
            {   var PaymentKeyResponse = await _getPaymentKeyByPaymentMethod(PaymentMethod.OnlineCard, price, userId);
                if (!string.IsNullOrEmpty(PaymentKeyResponse.ErrorMessage))
                {
                    OnlineCardIFrameResponse.ErrorMessage = PaymentKeyResponse.ErrorMessage;
                    return OnlineCardIFrameResponse;
                }
                var PaymentKeyToken = PaymentKeyResponse.Data;

                OnlineCardIFrameResponse.Data = IFrame + PaymentKeyToken;
                
                return OnlineCardIFrameResponse;
            }
            catch (Exception ex)
            {
                OnlineCardIFrameResponse.ErrorMessage = ex.Message;
                return OnlineCardIFrameResponse;
            }
        }

        // 2- Mobile Wallet
        public async Task<BasePaymentResponseDTO<string>> GetMoblieWalletUrl(int userId, string walletMobileNumber)
        {
            var MobileWalletUrlResponse = new BasePaymentResponseDTO<string>();

            var price = _unitOfWork.CartRepository.GetCartTotalByUserId(userId);

            try
            {
                var PaymentKeyResponse = await _getPaymentKeyByPaymentMethod(PaymentMethod.MobileWallet, price, userId);
                if (!string.IsNullOrEmpty(PaymentKeyResponse.ErrorMessage))
                {
                    MobileWalletUrlResponse.ErrorMessage = PaymentKeyResponse.ErrorMessage;
                    return MobileWalletUrlResponse;
                }
                var PaymentKeyToken = PaymentKeyResponse.Data;

                var RequestBody = new
                {
                    source = new
                    {
                        identifier = walletMobileNumber,
                        subtype = "WALLET"
                    },
                    payment_token = PaymentKeyToken
                };

                var JsonRequestBody = JsonConvert.SerializeObject(RequestBody);

                var content = new StringContent(JsonRequestBody, Encoding.UTF8, "application/json");

                var _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri("https://accept.paymob.com/api/acceptance/");

                HttpResponseMessage response = await _httpClient.PostAsync("payments/pay", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    dynamic? responseObj = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    MobileWalletUrlResponse.Data = responseObj.redirect_url;
                    if (string.IsNullOrEmpty(MobileWalletUrlResponse.Data))
                    {
                        MobileWalletUrlResponse.ErrorMessage = "Payment Failed";
                        return MobileWalletUrlResponse;
                    }

                    return MobileWalletUrlResponse;
                }
                else
                {
                    MobileWalletUrlResponse.ErrorMessage = $"{response.StatusCode}: Failed payment with mobile wallet";
                    return MobileWalletUrlResponse;
                }
            }
            catch (Exception ex)
            {
                MobileWalletUrlResponse.ErrorMessage = ex.Message;
                return MobileWalletUrlResponse;
            }
        }

        #region Test Enrollment
        //public bool EnrollAfterPayment(int userId)
        //{
        //    var carts = _unitOfWork.CartRepository.GetCartItemsByUserId(userId);
        //    foreach (var cart in carts)
        //    {
        //        var enrollment = new Enrollment
        //        {
        //            UserId = userId,
        //            CourseId = cart.CourseId,
        //            EnrollmentDate = DateTime.UtcNow,
        //            ProgressPercentage = 0,
        //            CompletedLessons = 0
        //        };
        //        _unitOfWork.EnrollmentRepository.AddEnrollment(enrollment);
        //        _unitOfWork.SaveChanges();

        //        //if (!_courseManager.EnrollUserInCourse(userId, cart.CourseId)) return false;
        //        //_unitOfWork.CartRepository.DeleteAllUserCartItems(userId);
        //    }

        //    return true;
        //} 
        #endregion

        /*------------------------------------- Payment Intention API Flow -------------------------------------*/
        // 1- Authentication Request
        private async Task<BasePaymentResponseDTO<string>> _getAuthenticationToken()
        {
            var AuthResponse = new BasePaymentResponseDTO<string>();
            
            string? ApiKey = _configuration["Paymob:ApiKey"];
            
            var RequestBody = new 
            {
                api_key = ApiKey 
            };

            var JsonReuestBody = JsonConvert.SerializeObject(RequestBody);

            var content = new StringContent(JsonReuestBody, Encoding.UTF8, "application/json");

            var _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://accept.paymob.com/api/");

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("auth/tokens", content);

                if(response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var responseObj = JsonConvert.DeserializeObject<TokenResponseDTO>(responseContent);
                    AuthResponse.Data = responseObj.token;

                    return AuthResponse;
                }
                else
                {
                    AuthResponse.ErrorMessage = $"{response.StatusCode}: Payment Authentication Request failed";
                    return AuthResponse;
                }
            }
            catch (Exception ex)
            {
                AuthResponse.ErrorMessage = ex.Message;
                return AuthResponse;
            }
        }

        // 2- Order Registration
        private async Task<BasePaymentResponseDTO<string>> _createOrderAndGetOrderId(decimal price)
        {
            var OrderResponse = new BasePaymentResponseDTO<string>();

            var AuthResponse = await _getAuthenticationToken();
            if (!string.IsNullOrEmpty(AuthResponse.ErrorMessage))
            {
                OrderResponse.ErrorMessage = AuthResponse.ErrorMessage;
                return OrderResponse;
            }
            var AuthToken = AuthResponse.Data;

            OrderReguest = new(AuthToken, price);

            var RequestBody = new
            {
                auth_token = OrderReguest.AuthToken,
                delivery_needed = OrderReguest.DeliveryNeeded,
                amount_cents = OrderReguest.AmountCents,
                currency = OrderReguest.Currency,
                items = OrderReguest.Items
            };

            var JsonRequestBody = JsonConvert.SerializeObject(RequestBody);

            var content = new StringContent(JsonRequestBody, Encoding.UTF8, "application/json");

            var _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://accept.paymob.com/api/");

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("ecommerce/orders", content);

                if(response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    dynamic? responseObj = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    int id = responseObj.id;
                    
                    OrderResponse.Data = id.ToString();
                    return OrderResponse;
                }
                else
                {
                    OrderResponse.ErrorMessage = $"{response.StatusCode}: Registering to payment order failed";
                    return OrderResponse;
                }
            }
            catch(Exception ex)
            {
                OrderResponse.ErrorMessage = ex.Message;
                return OrderResponse;
            }
        }

        // 3- Payment Key
        private async Task<BasePaymentResponseDTO<string>> _getPaymentKeyByPaymentMethod(PaymentMethod method, decimal price, int userId)
        {
            var PaymentKeyResponse = new BasePaymentResponseDTO<string>();

            int IntegrationId = (method) switch
            {
                PaymentMethod.OnlineCard => int.Parse(_configuration["Paymob:OnlineCardIntegrationId"]),
                PaymentMethod.MobileWallet => int.Parse(_configuration["Paymob:MobileWalletIntegrationId"]),
                _ => 0
            };

            var OrderResponse = await _createOrderAndGetOrderId(price);
            if (!string.IsNullOrEmpty(OrderResponse.ErrorMessage))
            {
                PaymentKeyResponse.ErrorMessage = OrderResponse.ErrorMessage;
                return PaymentKeyResponse;
            }
            var OrderId = OrderResponse.Data;

            PaymentKeyRequest = new(OrderReguest.AuthToken, OrderReguest.AmountCents.ToString(), OrderId, IntegrationId);

            var ReuestBody = new
            {
                auth_token = PaymentKeyRequest.auth_token,
                amount_cents = PaymentKeyRequest.amount_cents,
                expiration = PaymentKeyRequest.expiration,
                order_id = PaymentKeyRequest.order_id,
                billing_data = PaymentKeyRequest.billing_data,
                currency = PaymentKeyRequest.currency,
                integration_id = PaymentKeyRequest.integration_id
            };

            var JsonRequestBody = JsonConvert.SerializeObject(ReuestBody);

            var _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://accept.paymob.com/api/");

            var content = new StringContent(JsonRequestBody, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("acceptance/payment_keys", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var responseObj = JsonConvert.DeserializeObject<TokenResponseDTO>(responseContent);
                    PaymentKeyResponse.Data = responseObj.token;

                    return PaymentKeyResponse;
                }
                else
                {
                    PaymentKeyResponse.ErrorMessage = $"{response.StatusCode}: Failed to Create a payment Key";
                    return PaymentKeyResponse;
                }
            }
            catch (Exception ex)
            {
                PaymentKeyResponse.ErrorMessage = ex.Message;
                return PaymentKeyResponse;
            }
        }
    }
}
