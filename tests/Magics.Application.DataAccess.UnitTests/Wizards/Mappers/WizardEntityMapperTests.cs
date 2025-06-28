using FluentAssertions;
using Magics.Application.DataAccess.Wizards.Entity;
using Magics.Application.DataAccess.Wizards.Mappers;

namespace Magics.Application.DataAccess.UnitTests.Wizards.Mappers;

public class WizardEntityMapperTests
{
    [Fact]
    public void ToModel_MapsPropertiesCorrectly()
    {
        var entity = new WizardEntity
        {
            Id = 11,
            FirstName = "Minerva",
            LastName = "McGonagall",
            Patronymic = "Molly",
            Birthdate = new DateTime(1935, 10, 4),
            City = "Hogwarts",
            KnownMagicSkills = new[] { "Transfiguration" }
        };

        var model = entity.ToModel();

        model.Id.Should().Be(entity.Id);
        model.FirstName.Should().Be(entity.FirstName);
        model.LastName.Should().Be(entity.LastName);
        model.Patronymic.Should().Be(entity.Patronymic);
        model.Birthdate.Should().Be(entity.Birthdate);
        model.City.Should().Be(entity.City);
        model.KnownMagicSkills.Should().BeEquivalentTo(entity.KnownMagicSkills);
    }
}