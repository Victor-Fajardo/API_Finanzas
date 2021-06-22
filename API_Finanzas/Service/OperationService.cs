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
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OperationService(IOperationRepository operationRepository, IUnitOfWork unitOfWork)
        {
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
        }

        public  async Task<OperationResponse> DeleteAsync(int id)
        {
            var existingOperation = await _operationRepository.FindById(id);
            if (existingOperation == null)
                return new OperationResponse("Operation not found");
            try
            {
                _operationRepository.Remove(existingOperation);
                await _unitOfWork.CompleteAsync();
                return new OperationResponse(existingOperation);
            }
            catch (Exception ex)
            {
                return new OperationResponse($"An error ocurred while deleting Operation: {ex.Message}");
            }
        }

        public async Task<OperationResponse> GetByIdAsync(int id)
        {
            var existingOperation = await _operationRepository.FindById(id);
            if (existingOperation == null)
                return new OperationResponse("Operation not found");
            return new OperationResponse(existingOperation);
        }

        public async Task<IEnumerable<Operation>> ListAsync()
        {
            return await _operationRepository.ListAsync();
        }

        public async Task<OperationResponse> SaveAsync(Operation operation)
        {
            try
            {
                await _operationRepository.AddAsync(operation);
                await _unitOfWork.CompleteAsync();
                return new OperationResponse(operation);
            }
            catch (Exception ex)
            {
                return new OperationResponse($"An error ocurred while saving the Operation: {ex.Message}");
            }
        }

        public async Task<OperationResponse> UpdateAsync(int id, Operation operation)
        {
            var existingOperation = await _operationRepository.FindById(id);
            if (existingOperation == null)
                return new OperationResponse("Operation not found");
            existingOperation.Rate = operation.Rate;
            existingOperation.Discount = operation.Discount;
            existingOperation.NetValue = operation.NetValue;
            existingOperation.OutputValue = operation.OutputValue;
            existingOperation.Flow = operation.Flow;
            existingOperation.TCEA = operation.TCEA;
            try
            {
                _operationRepository.Update(existingOperation);
                await _unitOfWork.CompleteAsync();
                return new OperationResponse(existingOperation);
            }
            catch (Exception ex)
            {
                return new OperationResponse($"An error ocurred while updating the Operation: {ex.Message}");
            }
        }
    }
}
