using System.Security.Claims;
using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentDB.Services;

public class ProfileService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork) : IProfileService
{
    private readonly UserManager<ApplicationUser> userManager = userManager;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public ApplicationUser? Get(ClaimsPrincipal user)
    {
        var id = userManager.GetUserId(user);

        return userManager.Users
            .Include(u => u.Favourites)
            .Where(u => u.Id == id)
            .FirstOrDefault();
    }

    public async Task AddFavorite(ClaimsPrincipal user, Guid mediaId)
    {
        var media = unitOfWork.Repository<Media>()
                        .GetById(mediaId)
                    ?? throw new InvalidOperationException();

        var currentUser = Get(user)
                            ?? throw new UnauthorizedAccessException();

        if (currentUser.Favourites == null)
        {
            currentUser.Favourites = [media];
            return;
        }

        if (currentUser.Favourites.Contains(media))
        {
            throw new BadHttpRequestException("Media already in favourites.");
        }

        currentUser.Favourites.Add(media);
        await userManager.UpdateAsync(currentUser);
    }

    public async Task DeleteFavorite(ClaimsPrincipal user, Guid mediaId)
    {
        var media = unitOfWork.Repository<Media>()
                        .GetById(mediaId)
                    ?? throw new InvalidOperationException();

        var currentUser = Get(user)
                            ?? throw new UnauthorizedAccessException();

        if (currentUser.Favourites == null)
        {
            return;
        }

        if (!currentUser.Favourites.Contains(media))
        {
            throw new BadHttpRequestException("Media not in favourites.");
        }

        currentUser.Favourites.Remove(media);
        await userManager.UpdateAsync(currentUser);
    }
}
