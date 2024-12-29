using E_Learning.BL.DTO.Payment;

namespace E_Learning.BL.Managers.PaymentManager
{
    public interface IPaymentManager
    {
        Task<BasePaymentResponseDTO<string>> GetOnlineCardIFrame(int userId);
        Task<BasePaymentResponseDTO<string>> GetMoblieWalletUrl(int userId, string walletMobileNumber);
        //public bool EnrollAfterPayment(int userId);
    }
}
