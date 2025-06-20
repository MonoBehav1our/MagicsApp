using Api.Contracts.DTOs;
using DataAccess.Contracts;
using Services.Contracts;

namespace Services;

public class MagicsService(IMagicRepository repository) : IMagicsService
{
    public Task<CreateMagicResponse> CreateAsync(CreateMagicRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetWizardMagicsResponse> GetAllByWizardIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetStatusAsync(Guid magicId)
    {
        throw new NotImplementedException();
    }
}