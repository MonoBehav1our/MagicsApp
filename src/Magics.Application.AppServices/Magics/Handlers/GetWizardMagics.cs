using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Contracts.Magics.Responses;
using Magics.Application.AppServices.Magics.Mappers;

namespace Magics.Application.AppServices.Magics.Handlers;

public class GetWizardMagics(IMagicRepository repository) : IGetWizardMagics
{
    public async Task<GetWizardMagicsInternalResponse> Handle(long id)
    {
        var result = await repository.GetWizardMagicsAsync(id);
        
        return result.ToInternalResponse();
    }
}