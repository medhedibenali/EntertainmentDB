using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services;

public interface IRoleService
{
    public IEnumerable<ApplicationRole> GetAll();

    public Task Insert(RoleInput roleInput);
}
