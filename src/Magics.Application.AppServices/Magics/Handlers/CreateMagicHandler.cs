using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Contracts.Magics.Requests;

namespace Magics.Application.AppServices.Magics.Handlers;

public class CreateMagicHandler(IMagicRepository repository) : ICreateMagicHandler
{
    public async Task Handle(CreateInternalRequest request)
    {
        var magicEntity = new Magic
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
}