namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.NotFoundExceptions
{
    [Serializable]
    public class GetTokensException : NotFoundException
    {
        public GetTokensException()
            : base("get_tokens_exception")
        {
        }
    }
}
