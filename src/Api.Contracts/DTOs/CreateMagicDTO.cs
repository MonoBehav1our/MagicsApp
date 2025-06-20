namespace Api.Contracts.DTOs;

public record CreateMagicRequest()
{
    public Guid Id { get; init; }
    
    public long Wizard_Id { get; init; }
    
    public long Salary { get; init; }
    
    public int ExperienceYears { get; init; }
    
    public required string DesiredSkill { get; init; }
    
    public required DateTime CreatedAt { get; init; }
}

public record CreateMagicResponse()
{
    public Guid Id { get; init; }
    
    public long Wizard_Id { get; init; }
    
    public long Salary { get; init; }
    
    public int ExperienceYears { get; init; }
    
    public required string DesiredSkill { get; init; }
    
    public required DateTime CreatedAt { get; init; }
}