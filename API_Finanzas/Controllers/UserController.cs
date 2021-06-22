using API_Finanzas.Domain.Models;
using API_Finanzas.Domain.Services;
using API_Finanzas.Domain.Services.Communications;
using API_Finanzas.Extensions;
using API_Finanzas.Resource;
using API_Finanzas.Resource.Saves;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [SwaggerOperation(
            Summary = "List all Users",
            Description = "List of Users",
            OperationId = "ListAllUsers",
            Tags = new[] { "Users" }
            )]
        [SwaggerResponse(200, "List of Users", typeof(IEnumerable<UserResource>))]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resource = _mapper.Map<IEnumerable<User>,
                IEnumerable<UserResource>>(users);
            return resource;
        }

        // GET api/<UserController>/5
        [SwaggerOperation(
            Summary = "List all Users by Id",
            Description = "List of Users for an Id",
            OperationId = "ListAllUsersById",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "List Users for an Id", typeof(IEnumerable<UserResource>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetAllByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(resource);
        }

        // GET api/<UserController>/5
        [SwaggerOperation(
            Summary = "List all Users by Email",
            Description = "List of Users for an Email",
            OperationId = "ListAllOperationsByEmail",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "List Users for an Email", typeof(IEnumerable<UserResource>))]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetAllByEmailAsync(string email)
        {
            var result = await _userService.GetByEmailAsync(email);

            if (!result.Succes)
                return BadRequest(result.Message);
            var resource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(resource);
        }

        // POST api/<UserController>
        [SwaggerOperation(
            Summary = "Create an User",
            Description = "Create an User",
            OperationId = "CreateUser",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "User was created", typeof(UserResource))]
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var users = _mapper.Map<SaveUserResource, User>(resource);

            var result = await _userService.SaveAsync(users);

            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        // PUT api/<UserController>/5
        [SwaggerOperation(
           Summary = "Update an User",
           Description = "Update an User",
           OperationId = "UpdateUser",
           Tags = new[] { "Users" }
       )]
        [SwaggerResponse(200, "User was updated", typeof(UserResource))]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            var users = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, users);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        // DELETE api/<UserController>/5
        [SwaggerOperation(
            Summary = "Delete an User",
            Description = "Delete an User",
            OperationId = "DeleteUser",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "User was delete", typeof(UserResource))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        //Authentication
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Autheticate",
            Description = "Authenticate",
            OperationId = "Autheticate",
            Tags = new[] { "Users" }
        )]
        [SwaggerResponse(200, "Authenticate", typeof(UserResource))]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Invalid Username or Password" });

            return Ok(response);
        }
    }
}
