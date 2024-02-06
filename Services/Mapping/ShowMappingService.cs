using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class ShowMappingService(IUnitOfWork unitOfWork) : MediaMappingService<Show, ShowInput>(unitOfWork)
{
    public override Show Map(ShowInput showInput)
    {
        var show = new Show()
        {
            Synopsis = showInput.Synopsis,
            NumberOfSeasons = showInput.NumberOfSeasons,
            Stars = showInput.Stars == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: c => showInput.Stars.Contains(c.Id)),
            Creators = showInput.Creators == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => showInput.Creators.Contains(p.Id)),
            Soundtrack = showInput.Soundtrack == null ? null
                : (IList<Track>)unitOfWork.Repository<Track>()
                    .Get(filter: t => showInput.Soundtrack.Contains(t.Id))
        };

        show = MapMedia(showInput, show);

        return show;
    }
}
