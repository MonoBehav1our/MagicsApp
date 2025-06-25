using Magics.Application.AppServices.Contracts.Magics.Responses;

namespace Magics.Application.AppServices.Contracts.Magics.Handlers;

public interface IGetWizardMagics
{
    public Task<GetWizardMagicsInternalResponse> Handle(long id);
}