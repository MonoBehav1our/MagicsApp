namespace Magics.Application.Api.Contracts.Magics.Requests;

public record CreateMagicRequest()
{
    public long Wizard_Id { get; init; }
    
    public long Salary { get; init; }
    
    public int ExperienceYears { get; init; }
    
    public required string DesiredSkill { get; init; }
    
    public DateTime? CreatedAt { get; init; }
}