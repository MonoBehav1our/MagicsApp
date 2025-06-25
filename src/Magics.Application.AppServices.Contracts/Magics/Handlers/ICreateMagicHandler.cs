using Magics.Application.AppServices.Contracts.Magics.Requests;

namespace Magics.Application.AppServices.Contracts.Magics.Handlers;

public interface ICreateMagicHandler
{
    Task Handle(CreateInternalRequest request);
}