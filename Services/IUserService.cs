using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services;

public interface IUserService
{
    public IEnumerable<ApplicationUser> GetAll();

    public Task AssignRole(string username, RoleInput roleInput);
}
