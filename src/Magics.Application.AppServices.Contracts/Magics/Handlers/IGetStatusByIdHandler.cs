namespace Magics.Application.AppServices.Contracts.Magics.Handlers;

public interface IGetStatusByIdHandler
{
    Task<string> Handle(Guid magicId);
}