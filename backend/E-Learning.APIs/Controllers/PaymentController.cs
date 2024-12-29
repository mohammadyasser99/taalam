using E_Learning.BL.DTO.Payment;
using E_Learning.BL.Managers.PaymentManager;
using E_Learning.DAL.Models;
using E_Learning.DAL.UnitOfWorkDP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Learning.APIs.Controllers
{
    public class PaymentController : APIBaseController
    {
        private readonly IPaymentManager _paymentManager;
        private readonly IUnitOfWork _unitOfWork;

        /*------------------------------------------------------------------------*/
        public PaymentController(IPaymentManager paymentManager, IUnitOfWork unitOfWork)
        {
            _paymentManager = paymentManager;
            _unitOfWork = unitOfWork;
        }
        /*------------------------------------------------------------------------*/
        [HttpGet("OnlineCardIFrame")]
        public async Task<ActionResult<BasePaymentResponseDTO<string>>> OnlineCardPayment()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var response = await _paymentManager.GetOnlineCardIFrame(int.Parse(userId));
                if(!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }
        /*------------------------------------------------------------------------*/
        [HttpGet("MobileWalletUrl")]
        public async Task<ActionResult<BasePaymentResponseDTO<string>>> MobileWalletPayment(string walletMobileNumber)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var response = await _paymentManager.GetMoblieWalletUrl(int.Parse(userId), walletMobileNumber);
                if (!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }
        /*------------------------------------------------------------------------*/
        [HttpGet("Callback")]
        [AllowAnonymous]
        public IActionResult Callback()
        {
            var response = HttpContext.Request.Query;
            var id = response["id"].ToString();
            var success = response["success"].ToString();
            var amountCents = response["amount_cents"].ToString();
            var fullUrl = $"http://localhost:5062{Url.Action("ApprovePayment", "Payment", new { success })}";

            return Redirect(fullUrl);
        }
        /*------------------------------------------------------------------------*/
        [HttpGet("ApprovePayment")]
        public async Task<IActionResult> ApprovePayment(string success)
        {
            if (success == "true")
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    using (var unitOfWork = _unitOfWork)
                    {
                        var carts = unitOfWork.CartRepository.GetCartItemsByUserId(int.Parse(userId));
                        foreach (var cart in carts)
                        {
                            var enrollment = new Enrollment
                            {
                                UserId = int.Parse(userId),
                                CourseId = cart.CourseId,
                                EnrollmentDate = DateTime.UtcNow,
                                ProgressPercentage = 0,
                                CompletedLessons = 0
                            };

                            unitOfWork.EnrollmentRepository.AddEnrollment(enrollment);
                            unitOfWork.CartRepository.Delete(cart);
                        }

                         unitOfWork.SaveChanges();
                    }

                    // Redirect to the external URL after successful payment and enrollment
                    return Redirect($"http://localhost:4200/paymentapprove?success={success}");
                }
                else
                {
                    return Unauthorized(new { Message = "You are not authorized to enroll in our courses" });
                }
            }
            else
            {
                return Redirect($"http://localhost:4200/paymentapprove?success={success}");
            }
        }
    }
}
