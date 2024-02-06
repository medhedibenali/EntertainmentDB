using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class TrackMappingService : IMappingService<Track, TrackInput>
{
    public Track Map(TrackInput trackInput)
    {
        return new Track()
        {
            Duration = trackInput.Duration ;
        };
    }
}
