namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions
{
    [Serializable]
    public class AuthorizationException : BadRequestException
    {
        public AuthorizationException()
            : base("authorization_error")
        {
        }

        public AuthorizationException(string? message)
            : base($"{message}_authorization_error")
        {
        }
    }
}
