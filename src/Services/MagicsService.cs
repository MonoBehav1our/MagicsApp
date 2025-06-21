using Api.Contracts.DTOs;
using DataAccess;
using DataAccess.Contracts;
using Services.Contracts;

namespace Services;

public class MagicsService(IMagicRepository repository) : IMagicsService
{
    public async Task CreateAsync(CreateMagicRequest request)
    {
        var magicEntity = new MagicEntity
        {
            WizardId = request.Wizard_Id,
            Salary = request.Salary,
            ExperienceYears = request.ExperienceYears,
            DesiredSkill = request.DesiredSkill,
            Status = MagicStatus.Pending,
            CreatedAt = request.CreatedAt?.ToUniversalTime() ?? DateTime.UtcNow,
        };

        await repository.CreateAsync(magicEntity);
    }

    public async Task<GetWizardMagicsResponse> GetAllByWizardIdAsync(long id)
    {
        var result = await repository.GetAllByWizardIdAsync(id);
        var response = new GetWizardMagicsResponse
        {
            Skills = result.Select(magic => new MagicDTO
            {
                Id = magic.Id,
                Wizard_Id = magic.WizardId,
                Salary = magic.Salary,
                ExperienceYears = magic.ExperienceYears,
                DesiredSkill = magic.DesiredSkill,
                Status = magic.Status.ToString(),
                CreatedAt = magic.CreatedAt,
            }).ToList()
        };
        
        return response;
    }

    public async Task<string> GetStatusAsync(Guid magicId)
    {
        var result = await repository.GetStatusAsync(magicId);
        return result.ToString();
    }
}