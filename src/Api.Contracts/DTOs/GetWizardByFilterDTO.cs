namespace Api.Contracts.DTOs;

public record GetWizardByFilterRequest()
{
    public long? Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public DateTime? BirthDate { get; init; }

    public string? City { get; init; }

    public string[]? KnownMagicSkills { get; init; }
}

public record GetWizardByFilterResponse()
{
    public required long Id { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public string? Patronymic { get; init; }

    public required DateTime BirthDate { get; init; }

    public required string City { get; init; }

    public required string[] KnownMagicSkills { get; init; }
}