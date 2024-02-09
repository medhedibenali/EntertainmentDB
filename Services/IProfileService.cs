using System.Security.Claims;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services;

public interface IProfileService
{
    public ApplicationUser? Get(ClaimsPrincipal user);

    public Task AddFavorite(ClaimsPrincipal user, Guid mediaId);

    public Task DeleteFavorite(ClaimsPrincipal user, Guid mediaId);
}
