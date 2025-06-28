using Magics.Application.AppServices.Contracts.Infrastructure.Exceptions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.DataAccess.Data;
using Magics.Application.DataAccess.Magics.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Magics.Application.DataAccess.Magics.Repository;

public class MagicRepository(MagicsDbContext context) : IMagicRepository
{
    public async Task CreateAsync(Magic magic)
    {
        await context.magics.AddAsync(magic.ToEntity());
        await context.SaveChangesAsync();
    }

    public async Task<List<Magic>> GetWizardMagicsAsync(long wizardId)
    {
        var result = await context.magics
            .Where(m => m.WizardId == wizardId)
            .ToListAsync();
        
        return result.Select(m => m.ToModel()).ToList();
    }
    
    public async Task<MagicStatus> GetStatusAsync(Guid magicId)
    {
        var status = await context.magics
            .Where(m => m.Id == magicId)
            .Select(m => (MagicStatus?)m.Status)
            .FirstOrDefaultAsync();
        
        if (status == null)
            throw new NotFoundException($"Magic with id {magicId} not found");
        
        return status.Value;
    }
}