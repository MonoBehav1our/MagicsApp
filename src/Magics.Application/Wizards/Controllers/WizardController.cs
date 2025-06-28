using Magics.Application.AppServices.Contracts.Wizards.Handers;
using Magics.Application.Wizards.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Magics.Application.Wizards.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WizardsController(ILogger<WizardsController> logger, IGetWizardsByFilterWizardHandler getWizardsByFilterWizardHandler)
    : ControllerBase
{
    [HttpGet]
    public async Task<GetWizardsByFilterResponse> GetWizardsByFilter([FromBody] GetWizardsByFilterRequest request)
    {
        logger.LogInformation("Поиск мага по фильтру");

        var internalRequest = request.ToInternal();
        logger.LogInformation("Фильтр: {@Filter}", internalRequest);
        
        var result = await getWizardsByFilterWizardHandler.Handle(internalRequest);

        logger.LogInformation("Маг найден");

        return result.ToExternal();
    }
}