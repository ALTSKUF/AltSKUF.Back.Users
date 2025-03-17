namespace AltSKUF.Back.Users.Domain.Entity
{
    public class CreateFromEmailUserModel
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Role { get; set; }
    }
}
