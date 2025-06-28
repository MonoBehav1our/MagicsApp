using Magics.Application.AppServices.Contracts.Wizards.Models;

namespace Magics.Application.AppServices.Contracts.Wizards.Repository;

public interface IWizardRepository
{
    Task<List<Wizard>> GetByFilterAsync(WizardFilter filter);
}