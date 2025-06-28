using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Repository;

namespace Magics.Application.AppServices.Magics.Handlers;

public class GetStatusByIdHandler(IMagicRepository repository) : IGetStatusByIdHandler
{
    public async Task<MagicStatus> Handle(Guid magicId)
    {
        var result = await repository.GetStatusAsync(magicId);
        return result;
    }
}