using API_Finanzas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Services.Communications
{
    public class PaymentLetterResponse : BaseResponse<PaymentLetter>
    {
        public PaymentLetterResponse(PaymentLetter resource) : base(resource)
        {
        }

        public PaymentLetterResponse(string message) : base(message)
        {
        }
    }
}
