using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services.Mapping;

public class CompanyMappingService : IMappingService<Company, CompanyInput>
{
    public Company Map(CompanyInput companyInput)
    {
        return new Company()
        {
            Name = companyInput.Name,
            Origin = companyInput.Origin
        };
    }
}
