using EntertainmentDB.Models;

namespace EntertainmentDB.RequestModels
{
    public class PersonInput
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateOnly Birthday { get; set; }

        public string Origin { get; set; } = "";

    }
}
