using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.DataAccess.Wizards.Entity;

namespace Magics.Application.DataAccess.Wizards.Mappers;

public static class WizardEntityMapper
{
    public static Wizard ToModel(this WizardEntity wizard)
    {
        return new Wizard
        {
            Id = wizard.Id,
            FirstName = wizard.FirstName,
            LastName = wizard.LastName,
            Patronymic = wizard.Patronymic,
            Birthdate = wizard.Birthdate,
            City = wizard.City,
            KnownMagicSkills = wizard.KnownMagicSkills,
        };
    }
}