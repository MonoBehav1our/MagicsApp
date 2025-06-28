using FluentAssertions;
using Magics.Application.Api.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Responses;
using Magics.Application.Wizards.Mappers;

namespace Magics.Application.UnitTests.Wizards;

public class GetWizardsByFilterMapperTests
{
    [Fact]
    public void ToInternal_MapsPropertiesCorrectly()
    {
        var request = new GetWizardsByFilterRequest
        {
            Id = 42,
            FirstName = "Harry",
            LastName = "Potter",
            Patronymic = "James",
            BirthDate = new DateTime(1980, 7, 31),
            City = "Hogwarts",
            KnownMagicSkills = new[] { "Expelliarmus", "Lumos" }
        };

        var internalRequest = request.ToInternal();

        internalRequest.Id.Should().Be(request.Id);
        internalRequest.FirstName.Should().Be(request.FirstName);
        internalRequest.LastName.Should().Be(request.LastName);
        internalRequest.Patronymic.Should().Be(request.Patronymic);
        internalRequest.BirthDate.Should().Be(request.BirthDate);
        internalRequest.City.Should().Be(request.City);
        internalRequest.KnownMagicSkills.Should().BeEquivalentTo(request.KnownMagicSkills);
    }

    [Fact]
    public void ToExternal_MapsPropertiesCorrectly()
    {
        var internalResponse = new GetWizardsByFilterInternalResponse
        {
            Wizards = new System.Collections.Generic.List<global::Magics.Application.AppServices.Contracts.Wizards.Models.Wizard>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Hermione",
                    LastName = "Granger",
                    Birthdate = new DateTime(1979, 9, 19),
                    City = "Hogwarts",
                    KnownMagicSkills = new [] { "Spellcasting", "Potions" }
                }
            }
        };

        var response = internalResponse.ToExternal();

        response.Wizards.Should().HaveCount(1);
        var wizard = response.Wizards.First();
        wizard.Id.Should().Be(internalResponse.Wizards[0].Id);
        wizard.FirstName.Should().Be(internalResponse.Wizards[0].FirstName);
        wizard.LastName.Should().Be(internalResponse.Wizards[0].LastName);
        wizard.BirthDate.Should().Be(internalResponse.Wizards[0].Birthdate);
        wizard.City.Should().Be(internalResponse.Wizards[0].City);
        wizard.KnownMagicSkills.Should().BeEquivalentTo(internalResponse.Wizards[0].KnownMagicSkills);
    }
}