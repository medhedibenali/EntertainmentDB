using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class BookMappingService : IMappingService<Book, BookInput>
{
	public Book Map(BookInput bookInput)
	{
		return new Book()
		{
		book.Name = bookInput.Name;
		book.Isbn = bookInput.Isbn;
		};
	}
}


