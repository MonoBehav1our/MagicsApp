using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Magics.Mappers;

namespace Magics.Application.AppServices.UnitTests.Magics.Mappers;

public class GetWizardMagicsInternalMapperTests
{
    [Fact]
    public void ToInternalResponse_MapsListCorrectly()
    {
        var models = new List<Magic>
        {
            new Magic
            {
                Id = Guid.NewGuid(),
                WizardId = 10,
                Salary = 1500,
                ExperienceYears = 2,
                DesiredSkill = "Shield",
                Status = global::Magics.Application.AppServices.Contracts.Magics.Enums.MagicStatus.Pending,
                CreatedAt = DateTime.UtcNow
            }
        };

        var response = models.ToInternalResponse();

        response.Skills.Should().HaveCount(1);
        var skill = response.Skills[0];
        skill.Id.Should().Be(models[0].Id);
        skill.WizardId.Should().Be(models[0].WizardId);
        skill.Salary.Should().Be(models[0].Salary);
        skill.ExperienceYears.Should().Be(models[0].ExperienceYears);
        skill.DesiredSkill.Should().Be(models[0].DesiredSkill);
        skill.Status.Should().Be(models[0].Status);
        skill.CreatedAt.Should().Be(models[0].CreatedAt);
    }
}