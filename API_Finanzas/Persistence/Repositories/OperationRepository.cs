using API_Finanzas.Domain.Models;
using API_Finanzas.Domain.Persistence.Contexts;
using API_Finanzas.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Persistence.Repositories
{
    public class OperationRepository : BaseRepository, IOperationRepository
    {
        public OperationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Operation operation)
        {
            await _context.Operations.AddAsync(operation);
        }

        public async Task<Operation> FindById(int id)
        {
            return await _context.Operations.FindAsync(id);
        }

        public async Task<IEnumerable<Operation>> ListAsync()
        {
            return await _context.Operations.ToListAsync();
        }

        public async Task<IEnumerable<Operation>> ListByPaymentLetterIdAsync(int paymentletterId)
        {
            return await _context.Operations.Where(b => b.PaymentLetterId == paymentletterId).ToListAsync();
        }

        public void Remove(Operation operation)
        {
            _context.Operations.Remove(operation);
        }

        public void Update(Operation operation)
        {
            _context.Operations.Update(operation);
        }
    }
}
