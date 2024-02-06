using EntertainmentDB.Models;

namespace EntertainmentDB.RequestModels
{
    public abstract class PersonInput
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateOnly Birthday { get; set; }

        public string Origin { get; set; } = "";

        public  ICollection<Guid>? Movies { get; set; }

        public ICollection<Guid>? MoviesDirected { get; set; }

        public ICollection<Guid>? MoviesWritten { get; set; }

        public ICollection<Guid>? Shows { get; set; }

        public ICollection<Guid>? ShowsCreated { get; set; }

        public ICollection<Guid>? GamesDirected { get; set; }

        public ICollection<Guid>? Books { get; set; }

        public ICollection<Guid>? Tracks { get; set; }

        public ICollection<Guid>? FranchisesCreated { get; set; }
    }
}
