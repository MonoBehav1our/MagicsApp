using Magics.Application.AppServices.Contracts.Magics.Enums;

namespace Magics.Application.AppServices.Contracts.Magics.Handlers;

public interface IGetStatusByIdHandler
{
    Task<MagicStatus> Handle(Guid magicId);
}