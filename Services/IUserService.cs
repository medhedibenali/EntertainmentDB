using EntertainmentDB.Models;

namespace EntertainmentDB.Services;

public interface IUserService
{
    public IEnumerable<ApplicationUser> GetAll();

    public Task AssignRole(string username, string roleName);
}
