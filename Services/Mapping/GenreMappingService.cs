using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class GenreMappingService : IMappingService<Genre, GenreInput>
{
    public Genre Map(GenreInput genreInput)
    {
        return new Genre()
        {
            Name = genreInput.Name
        };
    }
}
