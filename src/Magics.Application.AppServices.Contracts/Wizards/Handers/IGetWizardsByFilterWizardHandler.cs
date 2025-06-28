using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Responses;

namespace Magics.Application.AppServices.Contracts.Wizards.Handers;

public interface IGetWizardsByFilterWizardHandler
{
    Task<GetWizardsByFilterInternalResponse> Handle(GetWizardsByFilterInternalRequest getWizardsByFilterRequest);
}
