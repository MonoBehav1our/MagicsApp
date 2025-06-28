using Magics.Application.AppServices.Contracts.Wizards.Models;

namespace Magics.Application.AppServices.Contracts.Wizards.Responses;

public record GetWizardsByFilterInternalResponse
{
    public required List<Wizard> Wizards { get; init; }
}