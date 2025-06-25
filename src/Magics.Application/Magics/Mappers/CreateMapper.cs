using Magics.Application.Api.Contracts.Magics.Requests;
using Magics.Application.AppServices.Contracts.Magics.Requests;

namespace Magics.Application.Magics.Mappers;

public static class CreateMapper
{
    public static CreateInternalRequest ToInternal(this CreateRequest request)
    {
        return new CreateInternalRequest
        {
            Wizard_Id = request.Wizard_Id,
            Salary = request.Salary,
            ExperienceYears = request.ExperienceYears,
            DesiredSkill = request.DesiredSkill,
            CreatedAt = request.CreatedAt,
        };
    }
}