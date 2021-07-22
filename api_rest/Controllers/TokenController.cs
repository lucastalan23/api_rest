using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using api_rest.Domain.Models;
using api_rest.Domain.Services;
using api_rest.Extensions;
using api_rest.Resources;
using api_rest.Util;
using AutoMapper;


using System.Threading.Tasks;

namespace api_rest.Controllers
{

    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration, IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> VerifyLogin([FromBody] TokenResource resources)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }

                var user = _mapper.Map<TokenResource, User>(resources);
                var result = await _userService.FirstOrDefaultAsync(user.Login, user.Password);

                if (!result.Success)
                {
                    return BadRequest("Error trying to login1");
                }

                var token = CryptoFunctions.GerarToken(user, _configuration["SecurityKey"]);

                return base.Ok(new
                {
                    error = false,
                    result = new
                    {
                        token,
                        user = new { user.IdUser, user.Login}
                    }
                });
            }
            catch (Exception)
            {
                var message = "Error trying to login2";
                return BadRequest(new { error = true, result = new { message} });

            }

        }
    }
}
