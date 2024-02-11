using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class EpisodeMappingService(IUnitOfWork unitOfWork)
    : IMappingService<Episode, EpisodeInput>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public Episode Map(EpisodeInput episodeInput)
    {
        var season = unitOfWork.Repository<Season>()
                        .GetById(episodeInput.Season)
                    ?? throw new InvalidOperationException();

        return new Episode()
        {
            Title = episodeInput.Title,
            Synopsis = episodeInput.Synopsis,
            Duration = episodeInput.Duration,
            EpisodeNumber = episodeInput.EpisodeNumber,
            Season = season
        };
    }
}
