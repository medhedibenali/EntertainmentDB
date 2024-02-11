using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class SeasonMappingService(IUnitOfWork unitOfWork)
    : IMappingService<Season, SeasonInput>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    public Season Map(SeasonInput seasonInput)
    {
        var show = unitOfWork.Repository<Show>()
                .GetById(seasonInput.Show)
            ?? throw new InvalidOperationException();

        return new Season()
        {
            Title = seasonInput.Title,
            Synopsis = seasonInput.Synopsis,
            SeasonNumber = seasonInput.SeasonNumber,
            NumberOfEpisodes = seasonInput.NumberOfEpisodes,
            Show = show
        };
    }
}
