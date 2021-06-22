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
        Task<IEnumerable<PaymentLetter>> ListByUserIdAsync(int userId);
        Task<PaymentLetterResponse> GetByIdAsync(int id);
        Task<PaymentLetterResponse> SaveAsync(PaymentLetter paymentLetter, int userId);
        Task<PaymentLetterResponse> UpdateAsync(int id, PaymentLetter paymentLetter);
        Task<PaymentLetterResponse> DeleteAsync(int id);
    }
}
