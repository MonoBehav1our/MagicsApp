using Api.Contracts.DTOs;
using DataAccess;
using DataAccess.Contracts;
using Services.Contracts;

namespace Services;

public class WizardService(IWizardRepository repository) : IWizardService
{
    public async Task<GetWizardByFilterResponse> GetByFiltersAsync(GetWizardByFilterRequest getWizardByFilterRequest)
    {
        var filter = new WizardFilter
        {
            Id = getWizardByFilterRequest.Id,
            FirstName = getWizardByFilterRequest.FirstName,
            LastName = getWizardByFilterRequest.LastName,
            Patronymic = getWizardByFilterRequest.Patronymic,
            Birthdate = getWizardByFilterRequest.BirthDate,
            City = getWizardByFilterRequest.City,
            KnownMagicSkills = getWizardByFilterRequest.KnownMagicSkills,
        };
        
        var entity = await repository.GetByFilterAsync(filter);
        
        var response = new GetWizardByFilterResponse
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Patronymic = entity.Patronymic,
            BirthDate = entity.Birthdate,
            City = entity.City,
            KnownMagicSkills = entity.KnownMagicSkills,
        };
        
        return response;
    }
}