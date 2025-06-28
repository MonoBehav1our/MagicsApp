using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.DataAccess.Magics.Entity;

namespace Magics.Application.DataAccess.Magics.Mappers;

public static class MagicMapper
{
    public static Magic ToModel(this MagicEntity entity)
    {
        return new Magic
        {
            Id = entity.Id,
            WizardId = entity.WizardId,
            Salary = entity.Salary,
            ExperienceYears = entity.ExperienceYears,
            DesiredSkill = entity.DesiredSkill,
            Status = entity.Status,
            CreatedAt = entity.CreatedAt,
        };
    }

    public static MagicEntity ToEntity(this Magic magic)
    {
        return new MagicEntity
        {
            Id = magic.Id,
            WizardId = magic.WizardId,
            Salary = magic.Salary,
            ExperienceYears = magic.ExperienceYears,
            DesiredSkill = magic.DesiredSkill,
            Status = magic.Status,
            CreatedAt = magic.CreatedAt,
        };
    }
}