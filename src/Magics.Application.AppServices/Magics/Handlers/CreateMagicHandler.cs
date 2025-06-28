using Magics.Application.AppServices.Contracts.Infrastructure.Exceptions;
using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Contracts.Magics.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.AppServices.Magics.Mappers;

namespace Magics.Application.AppServices.Magics.Handlers;

public class CreateMagicHandler(IMagicRepository repository, IWizardRepository wizardRepository) : ICreateMagicHandler
{
    public async Task Handle(CreateMagicInternalRequest request)
    {
        var filterById = new WizardFilter { Id = request.Wizard_Id };
        _ = await wizardRepository.GetByFilterAsync(filterById)
            ?? throw new NotFoundException();

        var magic = request.ToMagicModel();
        await repository.CreateAsync(magic);
    }
}