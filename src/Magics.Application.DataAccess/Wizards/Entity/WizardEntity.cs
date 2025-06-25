namespace Magics.Application.DataAccess.Wizards.Entity;

public class WizardEntity
{
    public required long Id { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public string? Patronymic { get; init; }

    public required DateTime Birthdate { get; init; }

    public required string City { get; init; }

    public required string[] KnownMagicSkills { get; init; }
}