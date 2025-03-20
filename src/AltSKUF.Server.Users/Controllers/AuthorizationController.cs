using AltSKUF.Back.Users.Domain.Extensions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions;
using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.NotFoundExceptions;
using AltSKUF.Back.Users.Domain.Interfaces;
using AltSKUF.Back.Users.Domain.Services;
using AltSKUF.Back.Users.Extensions;
using AltSKUF.Back.Users.Infrastructure.Entity.Requests;
using AltSKUF.Back.Users.Infrastructure.HttpClient.Authentication;
using AltSKUF.Back.Users.Persistance.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AltSKUF.Back.Users.Controllers
{
    [ApiController]
    [Route("/Auth")]
    public class AuthorizationController(
        IUserService userService,
        IAuthService authService,
        IAuthenticationClient authenticationClient) : Controller
    {
        [HttpGet("/Email")]
        public async Task<IActionResult> AuthFromEmail(
            [FromQuery] UserEmailAuthRequest request)
        {
            try
            {
                var userId = await authService.AuthFromEmail(
                    request.ToAuthModel());

                authenticationClient.HttpClient.DefaultRequestHeaders.Authorization =
                    new("Bearer", JwtExtensions.GetServicesToken());
                var tokens = await authenticationClient
                    .AuthenticationController.GetUserTokensWithService(userId);

                var user = await userService.GetUser(userId,
                    [UserComponents.Inform,
                     UserComponents.Details]);

                return Ok(user.ToAuthResponce(tokens));
            }
            catch (NotFoundException ex)
            { return NotFound(ex.Message); }
            catch (BadRequestException ex)
            { return BadRequest(ex.Message); }
        }

        [HttpPost("/Email")]
        public async Task<IActionResult> RegistrationFromEmail(
            [FromBody] UserEmailRegistrationRequest request)
        {
            try
            {
                var user = await userService.CreateUser(
                    request.ToCreateModel());

                user = await authService.AddMethod(
                    request.ToAddEmailMethodModel(user));

                var tokens = await authenticationClient
                    .AuthenticationController.GetUserTokensWithService(user.Id);

                return Ok(user.ToResponce());
            }
            catch (NotFoundException ex)
            { return NotFound(ex.Message); }
            catch (BadRequestException ex)
            { return BadRequest(ex.Message); }
        }
    }
}
