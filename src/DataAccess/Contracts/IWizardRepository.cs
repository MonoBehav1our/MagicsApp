namespace DataAccess.Contracts;

public interface IWizardRepository
{
    Task<WizardEntity> GetByFilterAsync(WizardFilter filter);
}