using Api.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Host;

[ApiController]
[Route("api/[controller]")]
public class WizardsController(ILogger<WizardsController> logger, IWizardService wizardService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetWizardsByFilter([FromBody] GetWizardByFilterRequest request)
    {
        try
        {
            var result = await wizardService.GetByFiltersAsync(request);
            //todo: logs
            return Ok(result);
        }
        catch (Exception ex)
        {
            //todo: logs
            return BadRequest(ex.Message);
        }
    }
}