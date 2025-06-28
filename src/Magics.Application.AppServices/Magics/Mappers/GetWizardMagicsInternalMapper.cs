using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Responses;

namespace Magics.Application.AppServices.Magics.Mappers;

public static class GetWizardMagicsInternalMapper
{
    public static GetWizardMagicsInternalResponse ToInternalResponse(this List<Magic> magics)
    {
        return new GetWizardMagicsInternalResponse
        {
            Skills = magics.Select(magic => new Magic
            {
                Id = magic.Id,
                WizardId = magic.WizardId,
                Salary = magic.Salary,
                ExperienceYears = magic.ExperienceYears,
                DesiredSkill = magic.DesiredSkill,
                Status = magic.Status,
                CreatedAt = magic.CreatedAt
            }).ToList()
        };
    }
}