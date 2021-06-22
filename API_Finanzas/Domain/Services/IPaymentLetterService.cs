using API_Finanzas.Domain.Models;
using API_Finanzas.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Services
{
    public interface IPaymentLetterService
    {
        Task<IEnumerable<PaymentLetter>> ListAsync();
        Task<PaymentLetterResponse> GetByIdAsync(int id);
        Task<PaymentLetterResponse> SaveAsync(PaymentLetter paymentLetter);
        Task<PaymentLetterResponse> UpdateAsync(int id, PaymentLetter paymentLetter);
        Task<PaymentLetterResponse> DeleteAsync(int id);
    }
}
