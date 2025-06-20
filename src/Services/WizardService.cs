using Api.Contracts.DTOs;
using Services.Contracts;

namespace Services;

public class WizardService() : IWizardService
{
    public Task<GetWizardByFilterResponse> GetByFiltersAsync(GetWizardByFilterRequest getWizardByFilterRequest)
    {
        throw new NotImplementedException();
    }
}