using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Responses;
using Magics.Application.Magics.Mappers;

namespace Magics.Application.UnitTests.Magics;

public class GetWizardMagicsRequestMapperTests
{
    [Fact]
    public void ToExternal_MapsPropertiesCorrectly()
    {
        var internalResponse = new GetWizardMagicsInternalResponse
        {
            Skills = new List<global::Magics.Application.AppServices.Contracts.Magics.Models.Magic>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    WizardId = 1,
                    Salary = 2000,
                    ExperienceYears = 3,
                    DesiredSkill = "Invisibility",
                    Status = AppServices.Contracts.Magics.Enums.MagicStatus.Approved,
                    CreatedAt = DateTime.UtcNow
                }
            }
        };

        var response = internalResponse.ToExternal();

        response.Skills.Should().HaveCount(1);
        var skill = response.Skills[0];
        skill.Id.Should().Be(internalResponse.Skills[0].Id);
        skill.WizardId.Should().Be(internalResponse.Skills[0].WizardId);
        skill.Salary.Should().Be(internalResponse.Skills[0].Salary);
        skill.ExperienceYears.Should().Be(internalResponse.Skills[0].ExperienceYears);
        skill.DesiredSkill.Should().Be(internalResponse.Skills[0].DesiredSkill);
        skill.Status.Should().Be(internalResponse.Skills[0].Status.ToString());
        skill.CreatedAt.Should().Be(internalResponse.Skills[0].CreatedAt);
    }
}