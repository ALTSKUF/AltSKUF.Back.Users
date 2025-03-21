namespace AltSKUF.Back.Users.Domain.Entity
{
    public class EditUserOptions
    {
        public string? UserName { get; set; } = null;
        public string? Email { get; set; } = null;
        public bool ConfirmedEmail { get; set; } = false;
        public string? Role { get; set; } = null;

        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
    }
}
