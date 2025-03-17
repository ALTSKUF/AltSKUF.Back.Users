namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions
{
    [Serializable]
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException()
        {
        }

        protected BadRequestException(string? message) : base(message)
        {
        }
    }
}
