using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Postgres;

public class PostgresMagicRepository(DataContext context) : IMagicRepository
{
    public async Task CreateAsync(MagicEntity magic)
    {
        ArgumentNullException.ThrowIfNull(magic);

        await context.MagicsSet.AddAsync(magic);
        await context.SaveChangesAsync();
    }

    public async Task<List<MagicEntity>> GetAllByWizardIdAsync(long wizardId)
    {
        var result = await context.MagicsSet
            .Where(m => m.Wizard_Id == wizardId)
            .ToListAsync();
        
        return result;
    }
    
    public async Task<MagicStatus> GetStatusAsync(Guid magicId)
    {
        var status = await context.MagicsSet
            .Where(m => m.Id == magicId)
            .Select(m => (MagicStatus?)m.Status)
            .FirstOrDefaultAsync();
        
        if (status == null)
            throw new NotFoundException($"Magic with id {magicId} not found");
        
        return status.Value;
    }
}