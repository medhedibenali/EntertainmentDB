﻿namespace EntertainmentDB.Models;

public class ApplicationUser
{
    public Guid Id { get; set; }

    public string Login { get; set; } = "";

    public string Password { get; set; } = "";

    public virtual ICollection<Media>? Favourites { get; set; }
}