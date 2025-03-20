namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException() 
            : base("bad_request")
        {
        }

        public BadRequestException(string? message) : base(message)
        {
        }
    }
}
