using Magics.Application.Api.Contracts.Wizards.Requests;
using Magics.Application.Api.Contracts.Wizards.Responses;
using Magics.Application.AppServices.Contracts.Wizards.Handers;
using Magics.Application.Wizards.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Magics.Application.Wizards.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WizardsController(ILogger<WizardsController> logger, ISearchByFilterWizardHandler searchByFilterWizardHandler)
    : ControllerBase
{
    [HttpGet]
    public async Task<GetByFilterResponse> GetWizardsByFilter([FromBody] GetByFilterRequest request)
    {
        logger.LogInformation("Поиск мага по фильтру");

        var internalRequest = request.ToInternal();
        logger.LogInformation("Фильтр: {@Filter}", internalRequest);
        
        var result = await searchByFilterWizardHandler.Handle(internalRequest);

        logger.LogInformation("Маг найден");

        return result.ToExternal();
    }
}