using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class TrackMappingService(IUnitOfWork unitOfWork)
    : MediaMappingService<Track, TrackInput>(unitOfWork)
{
    public override Track Map(TrackInput trackInput)
    {
        var track = new Track()
        {
            Duration = trackInput.Duration,
            Artists = trackInput.Artists == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => trackInput.Artists.Contains(p.Id)),
        };

        track = MapMedia(trackInput, track);

        return track;
    }
}
