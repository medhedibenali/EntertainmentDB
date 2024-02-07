using EntertainmentDB.DAL;
using EntertainmentDB.Models;

namespace EntertainmentDB.Services.Crud;

public class BookCrudService(IUnitOfWork unitOfWork) : CrudService<Book>(unitOfWork)
{
    public override Book? GetById(object id)
    {
        return unitOfWork.Repository<Book>()
            .Get(
                filter: b => b.Id.Equals(id),
                includeProperties: [
                    nameof(Book.Genres),
                    nameof(Book.Tags),
                    nameof(Book.Franchise),
                    nameof(Book.Authors),
                    nameof(Book.Publishers)
                ]
            )
            .FirstOrDefault();
    }
}
