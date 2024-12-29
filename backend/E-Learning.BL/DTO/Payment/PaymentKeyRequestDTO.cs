using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.Payment
{
    public class PaymentKeyRequestDTO
    {
        public string auth_token { get; set; }
        public string amount_cents { get; set; }
        public int expiration = 600; // 10 minutes
        public string order_id { get; set; }
        public BillingDataDTO billing_data = new BillingDataDTO();
        public string currency = "EGP";
        public int integration_id;

        public PaymentKeyRequestDTO(string authToken, string amountCents, string orderId, int integrationId)
        {
            this.auth_token = authToken;
            this.amount_cents = amountCents;
            this.order_id = orderId;
            this.integration_id = integrationId;
        }
    }
}
