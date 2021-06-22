using API_Finanzas.Domain.Models;
using API_Finanzas.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Services
{
    public interface IOperationService
    {
        Task<IEnumerable<Operation>> ListAsync();
        Task<IEnumerable<Operation>> ListByPaymentLetterIdAsync(int paymentLetterId);
        Task<OperationResponse> GetByIdAsync(int id);
        Task<OperationResponse> SaveAsync(Operation operation, int paymentLetterId);
        Task<OperationResponse> UpdateAsync(int id, Operation operation);
        Task<OperationResponse> DeleteAsync(int id);
    }
}
