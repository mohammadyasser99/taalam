using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.Payment
{
    public class OrderRegisterationDTO
    {
        public string AuthToken { get; set; }
        public readonly bool DeliveryNeeded = false;
        private decimal _amountCents;

        public decimal AmountCents
        {
            get => _amountCents;
            set => _amountCents = value * 100;
        }
        public readonly string Currency = "EGP";
        public readonly string[] Items = Array.Empty<string>();

        public OrderRegisterationDTO(string authToken, decimal price)
        {
            this.AuthToken = authToken;
            this.AmountCents = price;
        }
    }
}
