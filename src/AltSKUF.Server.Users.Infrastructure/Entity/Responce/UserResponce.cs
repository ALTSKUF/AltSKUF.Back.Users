namespace AltSKUF.Back.Users.Infrastructure.Entity.Responce
{
    public class UserResponce
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}