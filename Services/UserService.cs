using Microsoft.AspNetCore.Identity;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services;

public class UserService(UserManager<ApplicationUser> userManager) : IUserService
{
    private readonly UserManager<ApplicationUser> userManager = userManager;

    public IEnumerable<ApplicationUser> GetAll()
    {
        return userManager.Users;
    }

    public async Task AssignRole(string username, RoleInput roleInput)
    {
        var role = roleInput.Name;
        var user = await userManager.FindByNameAsync(username) ?? throw new Exception("Username not found");
        var result = await userManager.AddToRoleAsync(user, role);

        if (!result.Succeeded)
        {
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
}
