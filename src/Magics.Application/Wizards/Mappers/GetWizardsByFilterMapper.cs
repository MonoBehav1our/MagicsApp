using Magics.Application.Api.Contracts.Wizards.Models;
using Magics.Application.Api.Contracts.Wizards.Requests;
using Magics.Application.Api.Contracts.Wizards.Responses;
using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Responses;

namespace Magics.Application.Wizards.Mappers;

public static class GetWizardsByFilterMapper
{
    public static GetWizardsByFilterResponse ToExternal(this GetWizardsByFilterInternalResponse response)
    {
        return new GetWizardsByFilterResponse
        {
            Wizards = response.Wizards
                .Select(w => new Wizard
                {
                    Id = w.Id,
                    FirstName = w.FirstName,
                    LastName = w.LastName,
                    BirthDate = w.Birthdate,
                    City = w.City,
                    KnownMagicSkills = w.KnownMagicSkills
                }).ToList()
        };
    }

    public static GetWizardsByFilterInternalRequest ToInternal(this GetWizardsByFilterRequest request)
    {
        return new GetWizardsByFilterInternalRequest
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