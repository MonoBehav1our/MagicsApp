using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.Magics.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Magics.Application.Magics.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MagicsController(
    ILogger<MagicsController> logger,
    ICreateMagicHandler createMagicHandler,
    IGetWizardMagics getWizardMagics,
    IGetStatusByIdHandler getStatusByIdHandler)
    : ControllerBase
{
    [HttpPost]
    public async Task CreateMagic([FromBody] CreateMagicRequest magicRequest)
    {
        logger.LogInformation("Создание заявки...");

        await createMagicHandler.Handle(magicRequest.ToInternal());

        logger.LogInformation("Заявка создана");
    }

    [HttpGet("{id:guid}")]
    public async Task<string> GetMagicStatus(Guid id)
    {
        try
        {
            logger.LogInformation("Получение статуса заявки с id={Id}", id);
            
            var result = await getStatusByIdHandler.Handle(id);
            
            logger.LogInformation("Статус получен: {Result}", result);
            
            return result.ToString();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при получении статуса заявки с id={Id}", id);
            throw;
        }
    }

    [HttpGet("/api/wizard/{wizardId:long}/magics")]
    public async Task<GetWizardMagicsResponse> GetWizardMagics(long wizardId)
    {
        logger.LogInformation("Получение всех заявок мага с id={WizardId}", wizardId);

        var result = await getWizardMagics.Handle(wizardId);

        logger.LogInformation("Заявки получены. Количество заявок: {Count}", result.Skills.Count);

        return result.ToExternal();
    }
}