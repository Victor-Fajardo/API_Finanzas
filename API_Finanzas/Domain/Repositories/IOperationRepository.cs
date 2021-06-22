using API_Finanzas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Repositories
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Operation>> ListAsync();
        Task<IEnumerable<Operation>> ListByPaymentLetterIdAsync(int paymentletterId);
        Task AddAsync(Operation operation);
        Task<Operation> FindById(int id);
        void Update(Operation operation);
        void Remove(Operation operation);
    }
}
