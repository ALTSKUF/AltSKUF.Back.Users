namespace AltSKUF.Back.Users.Domain.Extensions.CustomExceptions.BadRequestExceptions
{
    [Serializable]
    public class IsAvalaibleExcepion : BadRequestException
    {
        public IsAvalaibleExcepion()
            : base("object_is_avalaible")
        {
        }

        public IsAvalaibleExcepion(string? message)
            : base($"{message}_is_avalaible")
        {
        }
    }
}
