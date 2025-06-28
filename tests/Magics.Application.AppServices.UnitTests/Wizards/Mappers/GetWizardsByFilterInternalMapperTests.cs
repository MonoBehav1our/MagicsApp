using FluentAssertions;
using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Wizards.Mappers;

namespace Magics.Application.AppServices.UnitTests.Wizards.Mappers;

public class GetWizardsByFilterInternalMapperTests
{
    [Fact]
    public void ToFilter_MapsPropertiesCorrectly()
    {
        var internalRequest = new GetWizardsByFilterInternalRequest
        {
            Id = 7,
            FirstName = "Albus",
            LastName = "Dumbledore",
            Patronymic = "Percival",
            BirthDate = new DateTime(1881, 8, 30),
            City = "Hogwarts",
            KnownMagicSkills = new[] { "Transfiguration", "Potions" }
        };

        var filter = internalRequest.ToFilter();

        filter.Id.Should().Be(internalRequest.Id);
        filter.FirstName.Should().Be(internalRequest.FirstName);
        filter.LastName.Should().Be(internalRequest.LastName);
        filter.Patronymic.Should().Be(internalRequest.Patronymic);
        filter.Birthdate.Should().Be(internalRequest.BirthDate);
        filter.City.Should().Be(internalRequest.City);
        filter.KnownMagicSkills.Should().BeEquivalentTo(internalRequest.KnownMagicSkills);
    }

    [Fact]
    public void ToInternalResponse_MapsListCorrectly()
    {
        var models = new List<Wizard>
        {
            new Wizard
            {
                Id = 10,
                FirstName = "Severus",
                LastName = "Snape",
                Patronymic = "Tobias",
                Birthdate = new DateTime(1960, 1, 9),
                City = "Hogwarts",
                KnownMagicSkills = new[] { "Potions", "Dark Arts" }
            }
        };

        var response = models.ToInternalResponse();

        response.Wizards.Should().HaveCount(1);
        var wizard = response.Wizards[0];
        wizard.Id.Should().Be(models[0].Id);
        wizard.FirstName.Should().Be(models[0].FirstName);
        wizard.LastName.Should().Be(models[0].LastName);
        wizard.Patronymic.Should().Be(models[0].Patronymic);
        wizard.Birthdate.Should().Be(models[0].Birthdate);
        wizard.City.Should().Be(models[0].City);
        wizard.KnownMagicSkills.Should().BeEquivalentTo(models[0].KnownMagicSkills);
    }
}