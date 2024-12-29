using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.BL.DTO.Payment
{
    public class BasePaymentResponseDTO<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
