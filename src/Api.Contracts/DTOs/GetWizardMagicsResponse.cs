namespace Api.Contracts.DTOs;

public record GetWizardMagicsResponse()
{
    public required List<MagicDTO> Skills { get; init; }
}