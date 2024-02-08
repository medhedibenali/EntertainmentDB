using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class BookMappingService(IUnitOfWork unitOfWork) : MediaMappingService<Book, BookInput>(unitOfWork)
{
    public override Book Map(BookInput bookInput)
    {
        var book = new Book()
        {
            Isbn = bookInput.Isbn,
            Synopsis = bookInput.Synopsis,
            Authors = bookInput.Authors == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => bookInput.Authors.Contains(p.Id)),
            Publishers = bookInput.Publishers == null ? null
                : (IList<Company>)unitOfWork.Repository<Company>()
                    .Get(filter: c => bookInput.Publishers.Contains(c.Id)),
        };

        book = MapMedia(bookInput, book);

        return book;
    }
}
