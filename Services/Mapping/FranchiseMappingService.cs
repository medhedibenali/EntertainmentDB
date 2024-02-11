using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class FranchiseMappingService(IUnitOfWork unitOfWork)
    : IMappingService<Franchise, FranchiseInput>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public Franchise Map(FranchiseInput franchiseInput)
    {
        return new Franchise()
        {
            Title = franchiseInput.Title,
            Description = franchiseInput.Description,
            Creators = franchiseInput.Creators == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => franchiseInput.Creators.Contains(p.Id))
        };
    }
}
