using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class SeasonCrudService(IUnitOfWork unitOfWork) : CrudService<Season>(unitOfWork)
{
    public override Season? GetById(object id)
    {
        return unitOfWork.Repository<Season>()
            .Get(
                filter: s => s.Id.Equals(id),
                includeProperties: [
                    nameof(Season.Show),
                    nameof(Season.Episodes)
                ]
            )
            .FirstOrDefault();
    }
}
