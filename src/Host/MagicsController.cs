using Api.Contracts.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Host;

[ApiController]
[Route("api/[controller]")]
public class MagicsController(ILogger<MagicsController> logger, IMagicsService magicsService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMagic([FromBody] CreateMagicRequest request)
    {
        try
        {
            var result = await magicsService.CreateMagic(request);
            //todo: logs
            return Ok(result);
        }
        catch (Exception ex)
        {
            //todo: logs
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMagicStatus(Guid id)
    {
        try
        {
            var result = await magicsService.GetMagicStatus(id);
            //todo: logs
            return Ok(result);
        }
        catch (Exception ex)
        {
            //todo: logs
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("api/wizard/{wizardId:long}/magics")]
    public async Task<IActionResult> GetWizardMagics(long wizardId)
    {
        try
        {
            var result = await magicsService.GetMagicsByWizardId(wizardId);
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