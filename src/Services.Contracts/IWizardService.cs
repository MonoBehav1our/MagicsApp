using Api.Contracts.DTOs;

namespace Services.Contracts;

public interface IWizardService
{
    Task<GetWizardByFilterResponse> GetByFiltersAsync(GetWizardByFilterRequest getWizardByFilterRequest);
}
