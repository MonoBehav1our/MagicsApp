using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Contracts.Magics.Responses;

namespace Magics.Application.AppServices.Magics.Handlers;

public class GetWizardMagics(IMagicRepository repository) : IGetWizardMagics
{
    public async Task<GetWizardMagicsInternalResponse> Handle(long id)
    {
        var result = await repository.GetAllByWizardIdAsync(id);
        var response = new GetWizardMagicsInternalResponse
        {
            Skills = result.Select(magic => new Magic
            {
                Id = magic.Id,
                WizardId = magic.WizardId,
                Salary = magic.Salary,
                ExperienceYears = magic.ExperienceYears,
                DesiredSkill = magic.DesiredSkill,
                Status = magic.Status,
                CreatedAt = magic.CreatedAt,
            }).ToList()
        };
        
        return response;
    }
}