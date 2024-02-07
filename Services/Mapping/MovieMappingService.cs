using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class MovieMappingService(IUnitOfWork unitOfWork) : MediaMappingService<Movie, MovieInput>(unitOfWork)
{
    public override Movie Map(MovieInput movieInput)
    {
        var movie = new Movie()
        {
            Duration = movieInput.Duration,
            Synopsis = movieInput.Synopsis,
            Stars = movieInput.Stars == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => movieInput.Stars.Contains(p.Id)),
            Writers = movieInput.Writers == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => movieInput.Writers.Contains(p.Id)),
            Directors = movieInput.Directors == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => movieInput.Directors.Contains(p.Id)),
            Producers = movieInput.Producers == null ? null
                : (IList<Company>)unitOfWork.Repository<Company>()
                    .Get(filter: c => movieInput.Producers.Contains(c.Id)),
            Soundtrack = movieInput.Soundtrack == null ? null
                : (IList<Track>)unitOfWork.Repository<Track>()
                    .Get(filter: t => movieInput.Soundtrack.Contains(t.Id)),
        };

        movie = MapMedia(movieInput, movie);

        return movie;
    }
}
