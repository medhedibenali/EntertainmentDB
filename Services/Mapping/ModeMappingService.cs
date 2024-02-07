using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class ModeMappingService : IMappingService<Mode, ModeInput>
{
    public Mode Map(ModeInput modeInput)
    {
        return new Mode()
        {
            Name = modeInput.Name,
            Description = modeInput.Description
        };
    }
}
