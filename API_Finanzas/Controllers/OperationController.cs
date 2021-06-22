using API_Finanzas.Domain.Models;
using API_Finanzas.Domain.Services;
using API_Finanzas.Extensions;
using API_Finanzas.Resource;
using API_Finanzas.Resource.Saves;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Finanzas.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        private readonly IMapper _mapper;

        public OperationController(IOperationService operationService, IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        // GET: api/<OperationController>
        [SwaggerOperation(
            Summary = "List all Operations",
            Description = "List of operations",
            OperationId = "ListAllOperations",
            Tags = new[] {"Operations"}
            )]
        [SwaggerResponse(200, "List of Operations", typeof(IEnumerable<OperationResource>))]
        [ProducesResponseType(typeof(IEnumerable<OperationResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<OperationResource>> GetAllAsync()
        {
            var operations = await _operationService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Operation>,
                IEnumerable<OperationResource>>(operations);
            return resource;
        }

        // GET api/<OperationController>/5
        [SwaggerOperation(
            Summary = "List all Operations by PaymentLetterId",
            Description = "List of Operations for a PaymentLetterId",
            OperationId = "ListAllOperationsByPaymentLetterId",
            Tags = new[] { "Operations" }
        )]
        [SwaggerResponse(200, "List Operations for a PaymentLetterId", typeof(IEnumerable<OperationResource>))]
        [HttpGet("id")]
        public async Task<IEnumerable<OperationResource>> GetAllByPaymentLetterIdIdAsync(int paymentLetterId)
        {
            var operation = await _operationService.ListByPaymentLetterIdAsync(paymentLetterId);
            var resources = _mapper
                .Map<IEnumerable<Operation>, IEnumerable<OperationResource>>(operation);
            return resources;
        }

        // POST api/<OperationController>
        [SwaggerOperation(
            Summary = "Create an Operation",
            Description = "Create an Operation",
            OperationId = "CreateOperation",
            Tags = new[] { "Operations" }
        )]
        [SwaggerResponse(200, "Operation was created", typeof(OperationResource))]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync([FromBody] SaveOperationResource resource, int paymentLetterId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var operations = _mapper.Map<SaveOperationResource, Operation>(resource);

            var result = await _operationService.SaveAsync(operations, paymentLetterId);

            if (!result.Succes)
                return BadRequest(result.Message);
            var operationsResource = _mapper.Map<Operation, OperationResource>(result.Resource);
            return Ok(operationsResource);
        }

        // PUT api/<OperationController>/5
        [SwaggerOperation(
           Summary = "Update an Operation",
           Description = "Update an Operation",
           OperationId = "UpdateOperation",
           Tags = new[] { "Operations" }
       )]
        [SwaggerResponse(200, "Operation was updated", typeof(OperationResource))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOperationResource resource)
        {
            var operations = _mapper.Map<SaveOperationResource, Operation>(resource);
            var result = await _operationService.UpdateAsync(id, operations);
            if (!result.Succes)
                return BadRequest(result.Message);
            var operationsResource = _mapper.Map<Operation, OperationResource>(result.Resource);
            return Ok(operationsResource);
        }

        // DELETE api/<OperationController>/5
        [SwaggerOperation(
            Summary = "Delete an Operation",
            Description = "Delete an Operation",
            OperationId = "DeleteOperation",
            Tags = new[] { "Operations" }
        )]
        [SwaggerResponse(200, "Operation was delete", typeof(OperationResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _operationService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var operationsResource = _mapper.Map<Operation, OperationResource>(result.Resource);
            return Ok(operationsResource);
        }
    }
}
