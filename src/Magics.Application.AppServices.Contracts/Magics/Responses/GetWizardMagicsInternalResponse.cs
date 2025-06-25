
using Magics.Application.AppServices.Contracts.Magics.Models;

namespace Magics.Application.AppServices.Contracts.Magics.Responses;

public record GetWizardMagicsInternalResponse
{
    public required List<Magic> Skills { get; init; }
}