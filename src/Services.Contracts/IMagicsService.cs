using Api.Contracts.DTOs;

namespace Services.Contracts;

public interface IMagicsService
{
    Task CreateAsync(CreateMagicRequest request);
    
    Task<GetWizardMagicsResponse> GetAllByWizardIdAsync(long id);
    
    Task<string> GetStatusAsync(Guid magicId);
}