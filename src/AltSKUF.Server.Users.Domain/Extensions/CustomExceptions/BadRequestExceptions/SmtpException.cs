namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions
{
    [Serializable]
    public class SmtpException : BadRequestException
    {
        public SmtpException()
            : base("smtp_exception")
        {
        }

        public SmtpException(string? message) : base(message)
        {
        }
    }
}
