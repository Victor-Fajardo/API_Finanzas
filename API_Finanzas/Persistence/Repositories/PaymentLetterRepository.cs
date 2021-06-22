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
    public class PaymentLetterRepository : BaseRepository, IPaymentLetterRepository
    {
        public PaymentLetterRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(PaymentLetter paymentLetter)
        {
            await _context.PaymentLetters.AddAsync(paymentLetter);
        }

        public async Task<PaymentLetter> FindById(int id)
        {
            return await _context.PaymentLetters.FindAsync(id);
        }

        public async Task<IEnumerable<PaymentLetter>> ListAsync()
        {
            return await _context.PaymentLetters.ToListAsync();
        }

        public void Remove(PaymentLetter paymentLetter)
        {
            _context.PaymentLetters.Remove(paymentLetter);
        }

        public void Update(PaymentLetter paymentLetter)
        {
            _context.PaymentLetters.Update(paymentLetter);
        }
    }
}
