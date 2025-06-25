using Magics.Application.AppServices.Contracts.Magics.Enums;

namespace Magics.Application.DataAccess.Magics.Entity;

public class MagicEntity
{
    public Guid Id { get; init; }
    
    public required long WizardId { get; init; }
    
    public required long Salary { get; init; }
    
    public required int ExperienceYears { get; init; }
    
    public required string DesiredSkill { get; init; }
    
    public required MagicStatus Status { get; init; }
    
    public required DateTime CreatedAt { get; init; }
}