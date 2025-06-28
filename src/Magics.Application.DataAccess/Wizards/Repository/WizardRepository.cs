using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.DataAccess.Data;
using Magics.Application.DataAccess.Wizards.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Magics.Application.DataAccess.Wizards.Repository;

public class WizardRepository(MagicsDbContext context) : IWizardRepository
{
    public async Task<List<Wizard>> GetByFilterAsync(WizardFilter filter)
    {
        var query = context.wizards.AsQueryable();

        if (filter.Id != null)
            query = query.Where(w => w.Id == filter.Id);

        if (filter.FirstName != null)
            query = query.Where(w => w.FirstName == filter.FirstName);

        if (filter.LastName != null)
            query = query.Where(w => w.LastName == filter.LastName);

        if (filter.Patronymic != null)
            query = query.Where(w => w.Patronymic == filter.Patronymic);

        if (filter.Birthdate != null)
            query = query.Where(w => w.Birthdate.Date.Equals(filter.Birthdate.Value.Date));

        if (filter.City != null)
            query = query.Where(w => w.City == filter.City);

        var list = await query.ToListAsync();

        if (filter.KnownMagicSkills is { Length: > 0 })
        {
            list = list
                .Where(w => w.KnownMagicSkills.Any(skill => filter.KnownMagicSkills.Contains(skill)))
                .ToList();
        }

        return list.Select(w => w.ToModel()).ToList();
    }
}