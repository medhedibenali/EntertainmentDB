using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class FranchiseCrudService(IUnitOfWork unitOfWork) : CrudService<Franchise>(unitOfWork)
{
    public override Franchise? GetById(object id)
    {
        return unitOfWork.Repository<Franchise>()
            .Get(
                filter: g => g.Id.Equals(id),
                includeProperties: [
                    nameof(Franchise.Creators),
                    nameof(Franchise.Media),
                ]
            )
            .FirstOrDefault();
    }
}
