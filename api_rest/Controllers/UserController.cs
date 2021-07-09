using api_rest.Domain.Models;
using api_rest.Domain.Services;
using api_rest.Extensions;
using api_rest.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resources) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var users = _mapper.Map<SaveUserResource, User>(resources);
            var result = await _userService.SaveAsync(users);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var UserResource = _mapper.Map<User, SaveUserResource>(result.User);
            return Ok(UserResource);

        }
        
        [Authorize()]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resources)
        {
            if (!ModelState.IsValid)
            {
                 return BadRequest(ModelState.GetErrorMessages());
            }

            var user = _mapper.Map<SaveUserResource, User>(resources);
            var result = await _userService.UpdateAsync(user, id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var UserResource = _mapper.Map<User, SaveUserResource>(result.User);
            return Ok(UserResource);
        }

        [Authorize()]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var userResource = _mapper.Map<User, UserResource>(result.User);
            return Ok(userResource);
        }
    }
}
