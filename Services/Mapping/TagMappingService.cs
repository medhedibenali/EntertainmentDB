using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class TagMappingService : IMappingService<Tag, TagInput>
{
    public Tag Map(TagInput tagInput)
    {
        return new Tag()
        {
            Name = tagInput.Name
        };
    }
}
