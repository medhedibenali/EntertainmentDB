using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class CompanyCrudService(IUnitOfWork unitOfWork) : CrudService<Company>(unitOfWork)
{
    public override Company? GetById(object id)
    {
        return unitOfWork.Repository<Company>()
            .Get(filter: c => c.Id.Equals(id),
                includeProperties: [
                    nameof(Company.BooksPublished),
                    nameof(Company.GamesDeveloped),
                    nameof(Company.GamesPublished),
                    nameof(Company.MoviesProduced),
                    nameof(Company.PlatformsDeveloped)
                ]
            )
            .FirstOrDefault();
    }
}
