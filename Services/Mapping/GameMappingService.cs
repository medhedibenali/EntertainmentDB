using EntertainmentDB.DAL;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class GameMappingService(IUnitOfWork unitOfWork)
    : MediaMappingService<Game, GameInput>(unitOfWork)
{
    public override Game Map(GameInput gameInput)
    {
        var game = new Game()
        {
            Synopsis = gameInput.Synopsis,
            Developers = gameInput.Developers == null ? null
                : (IList<Company>)unitOfWork.Repository<Company>()
                    .Get(filter: c => gameInput.Developers.Contains(c.Id)),
            Publishers = gameInput.Publishers == null ? null
                : (IList<Company>)unitOfWork.Repository<Company>()
                    .Get(filter: c => gameInput.Publishers.Contains(c.Id)),
            Directors = gameInput.Directors == null ? null
                : (IList<Person>)unitOfWork.Repository<Person>()
                    .Get(filter: p => gameInput.Directors.Contains(p.Id)),
            Soundtrack = gameInput.Soundtrack == null ? null
                : (IList<Track>)unitOfWork.Repository<Track>()
                    .Get(filter: t => gameInput.Soundtrack.Contains(t.Id)),
            Platforms = gameInput.Platforms == null ? null
                : (IList<Platform>)unitOfWork.Repository<Platform>()
                    .Get(filter: p => gameInput.Platforms.Contains(p.Id)),
            Modes = gameInput.Modes == null ? null
                : (IList<Mode>)unitOfWork.Repository<Mode>()
                    .Get(filter: m => gameInput.Modes.Contains(m.Id))
        };

        game = MapMedia(gameInput, game);

        return game;
    }
}
