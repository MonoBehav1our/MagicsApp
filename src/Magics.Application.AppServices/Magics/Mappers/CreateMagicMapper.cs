using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Requests;

namespace Magics.Application.AppServices.Magics.Mappers;

public static class CreateMagicMapper
{
    public static Magic ToMagicModel(this CreateMagicInternalRequest request)
    {
        return new Magic
        {
            WizardId = request.Wizard_Id,
            Salary = request.Salary,
            ExperienceYears = request.ExperienceYears,
            DesiredSkill = request.DesiredSkill,
            Status = MagicStatus.Pending,
            CreatedAt = request.CreatedAt?.ToUniversalTime() ?? DateTime.UtcNow
        };
    }
}