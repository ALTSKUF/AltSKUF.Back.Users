using AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions;

namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.NotFoundExceptions
{
    public class GetTokensException : NotFoundException
    {
        public GetTokensException()
            : base("get_tokens_exception")
        {
        }
    }
}
