using API_Finanzas.Domain.Models;
using API_Finanzas.Domain.Repositories;
using API_Finanzas.Domain.Services;
using API_Finanzas.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Service
{
    public class PaymentLetterService : IPaymentLetterService
    {
        private readonly IPaymentLetterRepository _paymentLetterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentLetterService(IPaymentLetterRepository paymentLetterRepository, IUnitOfWork unitOfWork)
        {
            _paymentLetterRepository = paymentLetterRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentLetterResponse> DeleteAsync(int id)
        {
            var existingPaymentLetter = await _paymentLetterRepository.FindById(id);
            if (existingPaymentLetter == null)
                return new PaymentLetterResponse("Payment Letter not found");
            try
            {
                _paymentLetterRepository.Remove(existingPaymentLetter);
                await _unitOfWork.CompleteAsync();
                return new PaymentLetterResponse(existingPaymentLetter);
            }
            catch (Exception ex)
            {
                return new PaymentLetterResponse($"An error ocurred while deleting Payment Letter: {ex.Message}");
            }
        }

        public async Task<PaymentLetterResponse> GetByIdAsync(int id)
        {
            var existingPaymentLetter = await _paymentLetterRepository.FindById(id);
            if (existingPaymentLetter == null)
                return new PaymentLetterResponse("Payment Letter not found");
            return new PaymentLetterResponse(existingPaymentLetter);
        }

        public async Task<IEnumerable<PaymentLetter>> ListAsync()
        {
            return await _paymentLetterRepository.ListAsync();
        }

        public async Task<PaymentLetterResponse> SaveAsync(PaymentLetter paymentLetter)
        {
            try
            {
                await _paymentLetterRepository.AddAsync(paymentLetter);
                await _unitOfWork.CompleteAsync();
                return new PaymentLetterResponse(paymentLetter);
            }
            catch (Exception ex)
            {
                return new PaymentLetterResponse($"An error ocurred while saving the Payment Letter: {ex.Message}");
            }
        }

        public async Task<PaymentLetterResponse> UpdateAsync(int id, PaymentLetter paymentLetter)
        {
            var existingPaymentLetter = await _paymentLetterRepository.FindById(id);
            if (existingPaymentLetter == null)
                return new PaymentLetterResponse("Payment Letter not found");
            existingPaymentLetter.RUC = paymentLetter.RUC;
            existingPaymentLetter.Currency = paymentLetter.Currency;
            existingPaymentLetter.Amount = paymentLetter.Amount;
            existingPaymentLetter.EmisisonDate = paymentLetter.EmisisonDate;
            existingPaymentLetter.ExpirationDate = paymentLetter.ExpirationDate;
            try
            {
                _paymentLetterRepository.Update(existingPaymentLetter);
                await _unitOfWork.CompleteAsync();
                return new PaymentLetterResponse(existingPaymentLetter);
            }
            catch (Exception ex)
            {
                return new PaymentLetterResponse($"An error ocurred while updating the Payment Letter: {ex.Message}");
            }
        }
    }
}
