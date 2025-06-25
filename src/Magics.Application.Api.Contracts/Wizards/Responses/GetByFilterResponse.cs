namespace Magics.Application.Api.Contracts.Wizards.Responses;

public record GetByFilterResponse()
{
    public required long Id { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public string? Patronymic { get; init; }

    public required DateTime BirthDate { get; init; }

    public required string City { get; init; }

    public required string[] KnownMagicSkills { get; init; }
}