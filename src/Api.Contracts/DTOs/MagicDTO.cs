namespace Api.Contracts.DTOs;

public record MagicDTO()
{
    public Guid Id { get; init; }
    
    public required long Wizard_Id { get; init; }
    
    public required long Salary { get; init; }
    
    public required int ExperienceYears { get; init; }
    
    public required string DesiredSkill { get; init; }
    
    public required string Status { get; init; }
    
    public required DateTime CreatedAt { get; init; }
}