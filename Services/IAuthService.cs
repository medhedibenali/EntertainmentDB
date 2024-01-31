using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services;

public interface IAuthService
{
    public Task Register(RegisterCredentials credentials);

    public Task<string> Login(LoginCredentials credentials);
}
