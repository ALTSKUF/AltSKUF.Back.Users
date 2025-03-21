namespace AltSKUF.Back.Users.Domain.Services
{
    public interface IVerifyService
    {
        Task SendVerifyMessage(Guid userId,string email);
        Task RefreshVerifyCode(Guid userId, string email);
        bool VerifyUser(Guid userId, string code);
    }
}
