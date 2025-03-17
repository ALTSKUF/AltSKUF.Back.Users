namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.NotFoundExceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base("object_not_found")
        {
        }

        public NotFoundException(string? message)
            : base($"{message}_not_found")
        {
        }
    }
}
