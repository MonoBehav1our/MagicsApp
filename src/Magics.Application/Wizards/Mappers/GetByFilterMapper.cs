using Magics.Application.Api.Contracts.Wizards.Requests;
using Magics.Application.Api.Contracts.Wizards.Responses;
using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Responses;

namespace Magics.Application.Wizards.Mappers;

public static class GetByFilterMapper
{
    public static GetByFilterResponse ToExternal(this GetByFilterInternalResponse response)
    {
        return new GetByFilterResponse
        {
            Id = response.Id,
            FirstName = response.FirstName,
            LastName = response.LastName,
            Patronymic = response.Patronymic,
            BirthDate = response.BirthDate,
            City = response.City,
            KnownMagicSkills = response.KnownMagicSkills,
        };
    }

    public static GetByFilterInternalRequest ToInternal(this GetByFilterRequest request)
    {
        return new GetByFilterInternalRequest
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic,
            BirthDate = request.BirthDate,
            City = request.City,
            KnownMagicSkills = request.KnownMagicSkills,
        };
    }
}