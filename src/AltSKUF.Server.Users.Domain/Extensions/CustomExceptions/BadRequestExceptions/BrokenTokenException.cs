namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions
{
    [Serializable]
    public class BrokenTokenException : BadRequestException
    {
        public BrokenTokenException()
            : base("broken_token") { }
    }
}

