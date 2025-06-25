namespace Magics.Application.AppServices.Contracts.Wizards.Requests;

public record GetByFilterInternalRequest
{
    public long? Id { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Patronymic { get; init; }

    public DateTime? BirthDate { get; init; }

    public string? City { get; init; }

    public string[]? KnownMagicSkills { get; init; }
}