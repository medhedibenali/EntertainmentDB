using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class TagCrudService(IUnitOfWork unitOfWork) : CrudService<Tag>(unitOfWork)
{
    public override Tag? GetById(object id)
    {
        return unitOfWork.Repository<Tag>()
            .Get(filter: t => t.Id.Equals(id), includeProperties: [nameof(Tag.Media)])
            .FirstOrDefault();
    }
}
