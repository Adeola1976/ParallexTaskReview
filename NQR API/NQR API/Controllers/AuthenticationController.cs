using Microsoft.AspNetCore.Mvc;
using NQR.Application.Service;
using NQR.Model.Dto;

namespace NQR_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        public IAuthentication _auth;

        public AuthenticationController(IAuthentication auth)
        {
            _auth = auth;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> GetToken()
        {
            var response = await _auth.GetToken();
            return Ok(response);
        }
    }
}
