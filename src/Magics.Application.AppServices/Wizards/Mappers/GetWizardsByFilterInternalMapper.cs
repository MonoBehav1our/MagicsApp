using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Responses;

namespace Magics.Application.AppServices.Wizards.Mappers;

public static class GetWizardsByFilterInternalMapper
{
    public static WizardFilter ToFilter(this GetWizardsByFilterInternalRequest request)
    {
        return new WizardFilter
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic,
            Birthdate = request.BirthDate,
            City = request.City,
            KnownMagicSkills = request.KnownMagicSkills
        };
    }

    public static GetWizardsByFilterInternalResponse ToInternalResponse(this List<Wizard> wizards)
    {
        return new GetWizardsByFilterInternalResponse
        {
            Wizards = wizards.Select(w => new Wizard
            {
                Id = w.Id,
                FirstName = w.FirstName,
                LastName = w.LastName,
                Patronymic = w.Patronymic,
                Birthdate = w.Birthdate,
                City = w.City,
                KnownMagicSkills = w.KnownMagicSkills
            }).ToList()
        };
    }
}