using FluentAssertions;
using Magics.Application.Api.Contracts.Magics.Requests;
using Magics.Application.Magics.Mappers;

namespace Magics.Application.UnitTests.Magics;

public class CreateMagicRequestMapperTests
{
    [Fact]
    public void ToInternal_MapsPropertiesCorrectly()
    {
        var request = new CreateMagicRequest
        {
            Wizard_Id = 1,
            Salary = 1000,
            ExperienceYears = 5,
            DesiredSkill = "Fireball",
            CreatedAt = DateTime.UtcNow
        };

        var internalRequest = request.ToInternal();

        internalRequest.Wizard_Id.Should().Be(request.Wizard_Id);
        internalRequest.Salary.Should().Be(request.Salary);
        internalRequest.ExperienceYears.Should().Be(request.ExperienceYears);
        internalRequest.DesiredSkill.Should().Be(request.DesiredSkill);
        internalRequest.CreatedAt.Should().Be(request.CreatedAt);
    }
}