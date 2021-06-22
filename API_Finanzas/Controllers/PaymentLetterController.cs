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
    public class PaymentLetterController : ControllerBase
    {
        private readonly IPaymentLetterService _paymentLetterService;
        private readonly IMapper _mapper;

        public PaymentLetterController(IPaymentLetterService paymentLetterService, IMapper mapper)
        {
            _paymentLetterService = paymentLetterService;
            _mapper = mapper;
        }

        // GET: api/<PaymentLetterController>
        [SwaggerOperation(
            Summary = "List all Payment Letters",
            Description = "List of Payment Letters",
            OperationId = "ListAllPaymentLetters",
            Tags = new[] { "Payment Letters" }
            )]
        [SwaggerResponse(200, "List of Payment Letters", typeof(IEnumerable<PaymentLetterResource>))]
        [ProducesResponseType(typeof(IEnumerable<PaymentLetterResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<PaymentLetterResource>> GetAllAsync()
        {
            var paymentLetters = await _paymentLetterService.ListAsync();
            var resource = _mapper.Map<IEnumerable<PaymentLetter>,
                IEnumerable<PaymentLetterResource>>(paymentLetters);
            return resource;
        }

        // GET api/<PaymentLetterController>/5
        [SwaggerOperation(
            Summary = "List all Payment Letters by Id",
            Description = "List of Payment Letters for an Id",
            OperationId = "ListAllPaymentLettersById",
            Tags = new[] { "Payment Letters" }
        )]
        [SwaggerResponse(200, "List Payment Letters for an Id", typeof(IEnumerable<PaymentLetterResource>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetAllByIdAsync(int id)
        {
            var result = await _paymentLetterService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<PaymentLetter, PaymentLetterResource>(result.Resource);
            return Ok(resource);
        }

        // POST api/<PaymentLetterController>
        [SwaggerOperation(
            Summary = "Create a Payment Letter",
            Description = "Create a Payment Letter",
            OperationId = "CreatePaymentLetter",
            Tags = new[] { "Payment Letters" }
        )]
        [SwaggerResponse(200, "Payment Letter was created", typeof(PaymentLetterResource))]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentLetterResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var paymentLetter = _mapper.Map<SavePaymentLetterResource, PaymentLetter>(resource);

            var result = await _paymentLetterService.SaveAsync(paymentLetter);

            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentLetterResource = _mapper.Map<PaymentLetter, PaymentLetterResource>(result.Resource);
            return Ok(paymentLetterResource);
        }

        // PUT api/<PaymentLetterController>/5
        [SwaggerOperation(
           Summary = "Update a Payment Letter",
           Description = "Update a Payment Letter",
           OperationId = "UpdatePaymentLetter",
           Tags = new[] { "Payment Letters" }
       )]
        [SwaggerResponse(200, "Payment Letter was updated", typeof(PaymentLetterResource))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentLetterResource resource)
        {
            var paymentLetter = _mapper.Map<SavePaymentLetterResource, PaymentLetter>(resource);
            var result = await _paymentLetterService.UpdateAsync(id, paymentLetter);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentLetterResource = _mapper.Map<PaymentLetter, PaymentLetterResource>(result.Resource);
            return Ok(paymentLetterResource);
        }

        // DELETE api/<PaymentLetterController>/5
        [SwaggerOperation(
            Summary = "Delete a Payment Letter",
            Description = "Delete a Payment Letter",
            OperationId = "DeletePaymentLetter",
            Tags = new[] { "Payment Letters" }
        )]
        [SwaggerResponse(200, "Payment Letter was delete", typeof(PaymentLetterResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paymentLetterService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var paymentLetterResource = _mapper.Map<PaymentLetter, PaymentLetterResource>(result.Resource);
            return Ok(paymentLetterResource);
        }
    }
}
