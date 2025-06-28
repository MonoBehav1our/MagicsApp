using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Models;

namespace Magics.Application.AppServices.Contracts.Magics.Repository;

public interface IMagicRepository
{
    Task CreateAsync(Magic magic);
    
    Task<List<Magic>> GetWizardMagicsAsync(long wizardId);
    
    Task<MagicStatus> GetStatusAsync(Guid magicId);
}