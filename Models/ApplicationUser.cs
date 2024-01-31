using Microsoft.AspNetCore.Identity;

namespace EntertainmentDB.Models;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Media>? Favourites { get; set; }
}
