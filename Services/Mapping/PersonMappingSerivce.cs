using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class PersonMappingService : IMappingService<Person, PersonInput>
{
    public Person Map(PersonInput personInput)
    {
        return new Person()
        {
            FirstName = personInput.FirstName,
            LastName = personInput.LastName,
            Birthday = personInput.Birthday,
            Origin = personInput.Origin
        };
    }
}
