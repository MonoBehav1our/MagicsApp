using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Requests;
using Magics.Application.AppServices.Magics.Mappers;

namespace Magics.Application.AppServices.UnitTests.Magics.Mappers;

public class CreateMagicInternalMapperTests
{
    [Fact]
    public void ToMagicModel_MapsPropertiesCorrectly()
    {
        var request = new CreateMagicInternalRequest
        {
            Wizard_Id = 1,
            Salary = 1000,
            ExperienceYears = 10,
            DesiredSkill = "Levitation",
            CreatedAt = new DateTime(2025, 6, 1, 12, 0, 0, DateTimeKind.Utc)
        };

        var magic = request.ToMagicModel();

        magic.WizardId.Should().Be(request.Wizard_Id);
        magic.Salary.Should().Be(request.Salary);
        magic.ExperienceYears.Should().Be(request.ExperienceYears);
        magic.DesiredSkill.Should().Be(request.DesiredSkill);
        magic.Status.Should().Be(MagicStatus.Pending);
        magic.CreatedAt.Should().Be(request.CreatedAt.Value);
    }

    [Fact]
    public void ToMagicModel_SetsCreatedAtToUtcNow_WhenNull()
    {
        var request = new CreateMagicInternalRequest
        {
            Wizard_Id = 1,
            Salary = 1000,
            ExperienceYears = 10,
            DesiredSkill = "Levitation",
            CreatedAt = null
        };

        var before = DateTime.UtcNow;
        var magic = request.ToMagicModel();
        var after = DateTime.UtcNow;

        magic.CreatedAt.Should().BeOnOrAfter(before).And.BeOnOrBefore(after);
    }
}