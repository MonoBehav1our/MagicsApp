using Magics.Application.AppServices.Contracts.Wizards.Handers;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Responses;
using Magics.Application.AppServices.Wizards.Mappers;

namespace Magics.Application.AppServices.Wizards.Handlers;

public class GetWizardsByFilterWizardHandler(IWizardRepository repository) : IGetWizardsByFilterWizardHandler
{
    public async Task<GetWizardsByFilterInternalResponse> Handle(
        GetWizardsByFilterInternalRequest getWizardsByFilterRequest)
    {
        var filter = getWizardsByFilterRequest.ToFilter();
        
        var entities = await repository.GetByFilterAsync(filter);
        
        return entities.ToInternalResponse();
    }
}