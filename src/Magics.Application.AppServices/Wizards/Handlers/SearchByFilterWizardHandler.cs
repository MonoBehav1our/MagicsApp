using Magics.Application.Api.Contracts.Wizards.Requests;
using Magics.Application.Api.Contracts.Wizards.Responses;
using Magics.Application.AppServices.Contracts.Wizards.Handers;
using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Responses;

namespace Magics.Application.AppServices.Wizards.Handlers;

public class SearchByFilterWizardHandler(IWizardRepository repository) : ISearchByFilterWizardHandler
{
    public async Task<GetByFilterInternalResponse> Handle(GetByFilterInternalRequest getByFilterRequest)
    {
        var filter = new WizardFilter
        {
            Id = getByFilterRequest.Id,
            FirstName = getByFilterRequest.FirstName,
            LastName = getByFilterRequest.LastName,
            Patronymic = getByFilterRequest.Patronymic,
            Birthdate = getByFilterRequest.BirthDate,
            City = getByFilterRequest.City,
            KnownMagicSkills = getByFilterRequest.KnownMagicSkills,
        };
        
        var entity = await repository.GetByFilterAsync(filter);
        
        var response = new GetByFilterInternalResponse
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