namespace DataAccess;

public class MagicEntity
{
    public required Guid Id { get; init; }
    
    public required long Wizard_Id { get; init; }
    
    public required long Salary { get; init; }
    
    public required int ExperienceYears { get; init; }
    
    public required string DesiredSkill { get; init; }
    
    public required MagicStatus Status { get; init; }
    
    public required DateTime CreatedAt { get; init; }
}