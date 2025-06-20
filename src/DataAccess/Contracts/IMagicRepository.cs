namespace DataAccess.Contracts;

public interface IMagicRepository
{
    Task CreateAsync(MagicEntity magic);
    
    Task<List<MagicEntity>> GetAllByWizardIdAsync(long wizardId);
    
    Task<MagicStatus> GetStatusAsync(Guid magicId);
}