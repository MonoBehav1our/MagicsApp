using Magics.Application.Api.Contracts.Wizards.Models;

namespace Magics.Application.Api.Contracts.Wizards.Responses;

public record GetWizardsByFilterResponse()
{
    public required List<Wizard> Wizards { get; init; }
}