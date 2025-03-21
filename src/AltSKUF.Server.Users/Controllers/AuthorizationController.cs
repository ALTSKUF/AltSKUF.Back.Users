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
        IVerifyService verifyService,
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

                await verifyService.SendVerifyMessage(userId, request.Email);

                return Ok(userId);
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

                await verifyService.SendVerifyMessage(user.Id, request.Email);

                return Ok(user.Id);
            }
            catch (NotFoundException ex)
            { return NotFound(ex.Message); }
            catch (BadRequestException ex)
            { return BadRequest(ex.Message); }
        }

        [HttpGet("/Email/Verify/{userId}")]
        public async Task<IActionResult> VerifyFromEmail(
            [FromRoute] Guid userId,
            [FromQuery] string code)
        {
            try
            {
                if (!verifyService.VerifyUser(userId, code))
                    throw new BadRequestException("code_error");

                var user = await userService.GetUser(userId,
                    [UserComponents.Inform,
                     UserComponents.Details]);

                authenticationClient.HttpClient.DefaultRequestHeaders.Authorization = 
                    new("Bearer", JwtExtensions.GetServicesToken());
                var tokens = await authenticationClient.AuthenticationController.GetUserTokensWithService(userId);

                user = await userService.EditUser(user, new()
                {
                    ConfirmedEmail = true
                });

                return Ok(user.ToAuthResponce(tokens));
            }
            catch (NotFoundException ex)
            { return NotFound(ex.Message); }
            catch (BadRequestException ex)
            { return BadRequest(ex.Message); }
        }
    }
}
