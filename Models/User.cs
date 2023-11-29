﻿namespace EntertainmentDB.Models
{
    public class User
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public virtual ICollection<Media>? Favourites { get; set; }
    }
}