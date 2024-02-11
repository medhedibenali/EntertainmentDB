using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class PlatformMappingService(IUnitOfWork unitOfWork)
    : IMappingService<Platform, PlatformInput>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public Platform Map(PlatformInput platformInput)
    {
        var developer = unitOfWork.Repository<Company>()
                            .GetById(platformInput.Developer)
                        ?? throw new InvalidOperationException();

        return new Platform()
        {
            Name = platformInput.Name,
            Description = platformInput.Description,
            ReleaseDate = platformInput.ReleaseDate,
            Developer = developer
        };
    }
}
