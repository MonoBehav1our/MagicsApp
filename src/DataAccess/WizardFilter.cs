namespace DataAccess;

public class WizardFilter
{
    public long? Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public DateTime? Birthdate { get; init; }

    public string? City { get; init; }

    public string[]? KnownMagicSkills { get; init; }
}