using Magics.Application.Api.Contracts.Magics.Models;
using Magics.Application.Api.Contracts.Magics.Responses;
using Magics.Application.AppServices.Contracts.Magics.Responses;

namespace Magics.Application.Magics.Mappers;

public static class GetWizardMagicsRequestMapper
{
    public static GetWizardMagicsResponse ToExternal(this GetWizardMagicsInternalResponse response)
    {
        return new GetWizardMagicsResponse
        {
            Skills = response.Skills.Select(s => new Magic
            {
                Id = s.Id,
                WizardId = s.WizardId,
                Salary = s.Salary,
                Status = s.Status.ToString(),
                CreatedAt = s.CreatedAt,
                DesiredSkill = s.DesiredSkill,
                ExperienceYears = s.ExperienceYears,
            }).ToList(),
        };
    }
}