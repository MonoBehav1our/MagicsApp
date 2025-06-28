using Magics.Application.AppServices.Contracts.Magics.Requests;

namespace Magics.Application.Magics.Mappers;

public static class CreateMagicRequestMapper
{
    public static CreateMagicInternalRequest ToInternal(this CreateMagicRequest magicRequest)
    {
        return new CreateMagicInternalRequest
        {
            Wizard_Id = magicRequest.Wizard_Id,
            Salary = magicRequest.Salary,
            ExperienceYears = magicRequest.ExperienceYears,
            DesiredSkill = magicRequest.DesiredSkill,
            CreatedAt = magicRequest.CreatedAt,
        };
    }
}