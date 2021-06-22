using API_Finanzas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Repositories
{
    public interface IPaymentLetterRepository
    {
        Task<IEnumerable<PaymentLetter>> ListAsync();
        Task AddAsync(PaymentLetter paymentLetter);
        Task<PaymentLetter> FindById(int id);
        void Update(PaymentLetter paymentLetter);
        void Remove(PaymentLetter paymentLetter);
    }
}
