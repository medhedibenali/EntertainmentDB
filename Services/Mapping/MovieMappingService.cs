using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class MovieMappingService : IMappingService<Movie, MovieInput>
{
    public Movie Map(MovieInput movieInput)
    {
        return new Movie()
        {
            Duration = movieInput.Duration ;
            Synopsis = movieInput.Synopsis ;
        };
    }
}
