namespace Magics.Application.Api.Contracts.Wizards.Requests;

public record GetByFilterRequest()
{
    public long? Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public DateTime? BirthDate { get; init; }

    public string? City { get; init; }

    public string[]? KnownMagicSkills { get; init; }
}