using AltSKUF.Back.Users.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions;

namespace AltSKUF.Back.Users.Controllers
{
    [ApiController]
    [Route("Secret")]
    public class SecretController : Controller
    {
        [Authorize("Services")]
        [HttpPut("Refresh")]
        public IActionResult RefreshTokens()
        {
            try
            {
                var claimSecret = User.Claims.FirstOrDefault(_ => _.Type == "secret")
                    ?? throw new BrokenTokenException();
                var secret = claimSecret.Value;

                SercretExtensions.UpdateAccessSecret(secret);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
