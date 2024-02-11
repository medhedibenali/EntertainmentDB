using Microsoft.AspNetCore.Identity;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services;

public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{
    private readonly RoleManager<ApplicationRole> roleManager = roleManager;

    public IEnumerable<ApplicationRole> GetAll()
    {
        return roleManager.Roles;
    }

    public async Task Insert(RoleInput roleInput)
    {
        var name = roleInput.Name;
        var roleExist = await roleManager.RoleExistsAsync(name);

        if (roleExist)
        {
            return;
        }

        var role = new ApplicationRole()
        {
            Name = name
        };

        await roleManager.CreateAsync(role);
    }
}
