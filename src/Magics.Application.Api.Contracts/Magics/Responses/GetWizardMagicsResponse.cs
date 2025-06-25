using Magics.Application.Api.Contracts.Magics.Models;

namespace Magics.Application.Api.Contracts.Magics.Responses;

public record GetWizardMagicsResponse()
{
    public required List<Magic> Skills { get; init; }
}