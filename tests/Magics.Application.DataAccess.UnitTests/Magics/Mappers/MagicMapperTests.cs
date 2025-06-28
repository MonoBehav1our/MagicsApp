using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.DataAccess.Magics.Entity;
using Magics.Application.DataAccess.Magics.Mappers;

namespace Magics.Application.DataAccess.UnitTests.Magics.Mappers;

public class MagicMapperTests
{
    [Fact]
    public void ToModel_MapsPropertiesCorrectly()
    {
        var entity = new MagicEntity
        {
            Id = Guid.NewGuid(),
            WizardId = 5,
            Salary = 1200,
            ExperienceYears = 4,
            DesiredSkill = "Flight",
            Status = global::Magics.Application.AppServices.Contracts.Magics.Enums.MagicStatus.Approved,
            CreatedAt = DateTime.UtcNow
        };

        var model = entity.ToModel();

        model.Id.Should().Be(entity.Id);
        model.WizardId.Should().Be(entity.WizardId);
        model.Salary.Should().Be(entity.Salary);
        model.ExperienceYears.Should().Be(entity.ExperienceYears);
        model.DesiredSkill.Should().Be(entity.DesiredSkill);
        model.Status.Should().Be(entity.Status);
        model.CreatedAt.Should().Be(entity.CreatedAt);
    }

    [Fact]
    public void ToEntity_MapsPropertiesCorrectly()
    {
        var model = new Magic
        {
            Id = Guid.NewGuid(),
            WizardId = 5,
            Salary = 1200,
            ExperienceYears = 4,
            DesiredSkill = "Flight",
            Status = global::Magics.Application.AppServices.Contracts.Magics.Enums.MagicStatus.Approved,
            CreatedAt = DateTime.UtcNow
        };

        var entity = model.ToEntity();

        entity.Id.Should().Be(model.Id);
        entity.WizardId.Should().Be(model.WizardId);
        entity.Salary.Should().Be(model.Salary);
        entity.ExperienceYears.Should().Be(model.ExperienceYears);
        entity.DesiredSkill.Should().Be(model.DesiredSkill);
        entity.Status.Should().Be(model.Status);
        entity.CreatedAt.Should().Be(model.CreatedAt);
    }
}