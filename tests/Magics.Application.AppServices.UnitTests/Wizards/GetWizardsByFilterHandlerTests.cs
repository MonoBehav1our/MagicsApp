using FluentAssertions;
using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.AppServices.Contracts.Wizards.Requests;
using Magics.Application.AppServices.Wizards.Handlers;
using NSubstitute;

namespace Magics.Application.AppServices.UnitTests.Wizards;

public class GetWizardsByFilterWizardHandlerTests
{
    [Fact]
    public async Task FilterById_ReturnsSingleWizard()
    {
        var repository = Substitute.For<IWizardRepository>();
        var expected = new List<Wizard> { GetWizards()[0] };
        repository.GetByFilterAsync(Arg.Is<WizardFilter>(f => f.Id == 1)).Returns(expected);

        var handler = new GetWizardsByFilterWizardHandler(repository);
        var request = new GetWizardsByFilterInternalRequest { Id = 1 };

        var result = await handler.Handle(request);

        result.Wizards.Should().BeEquivalentTo(expected, x => x.Excluding(w => w.Id));
        await repository.Received(1).GetByFilterAsync(Arg.Any<WizardFilter>());
    }

    [Fact]
    public async Task EmptyFilter_ReturnsAllWizards()
    {
        var repository = Substitute.For<IWizardRepository>();
        var expected = GetWizards();
        repository.GetByFilterAsync(Arg.Is<WizardFilter>(f =>
            f.Id == null &&
            f.FirstName == null &&
            f.LastName == null &&
            f.Patronymic == null &&
            f.Birthdate == null &&
            f.City == null &&
            f.KnownMagicSkills == null
        )).Returns(expected);

        var handler = new GetWizardsByFilterWizardHandler(repository);
        var request = new GetWizardsByFilterInternalRequest();

        var result = await handler.Handle(request);

        result.Wizards.Should().BeEquivalentTo(expected, x => x.Excluding(w => w.Id));
        await repository.Received(1).GetByFilterAsync(Arg.Any<WizardFilter>());
    }

    [Fact]
    public async Task FullFilter_ReturnsMatchingWizards()
    {
        var repository = Substitute.For<IWizardRepository>();
        var expected = GetWizards().Where(w => w.City == "Hogsmeade").ToList();

        repository.GetByFilterAsync(Arg.Is<WizardFilter>(f =>
            f.FirstName == "Harry" &&
            f.LastName == "Potter" &&
            f.Patronymic == "James" &&
            f.Birthdate == new DateTime(1980, 7, 31) &&
            f.City == "Hogsmeade" &&
            f.KnownMagicSkills!.SequenceEqual(new[] { "Invisibility", "Expelliarmus" })
        )).Returns(expected);

        var handler = new GetWizardsByFilterWizardHandler(repository);
        var request = new GetWizardsByFilterInternalRequest
        {
            FirstName = "Harry",
            LastName = "Potter",
            Patronymic = "James",
            BirthDate = new DateTime(1980, 7, 31),
            City = "Hogsmeade",
            KnownMagicSkills = ["Invisibility", "Expelliarmus"]
        };

        var result = await handler.Handle(request);

        result.Wizards.Should().BeEquivalentTo(expected, x => x.Excluding(w => w.Id));
        await repository.Received(1).GetByFilterAsync(Arg.Any<WizardFilter>());
    }

    [Fact]
    public async Task FullFilter_ReturnsEmptyList_WhenNoMatch()
    {
        var repository = Substitute.For<IWizardRepository>();
        repository.GetByFilterAsync(Arg.Any<WizardFilter>()).Returns([]);

        var handler = new GetWizardsByFilterWizardHandler(repository);
        var request = new GetWizardsByFilterInternalRequest
        {
            FirstName = "Gandalf",
            LastName = "TheGrey",
            Patronymic = "Unknown",
            BirthDate = new DateTime(1500, 1, 1),
            City = "MiddleEarth",
            KnownMagicSkills = ["Fireworks"]
        };

        var result = await handler.Handle(request);

        result.Wizards.Should().BeEmpty();
        await repository.Received(1).GetByFilterAsync(Arg.Any<WizardFilter>());
    }

    private List<Wizard> GetWizards() => new()
    {
        new Wizard
        {
            Id = 1,
            FirstName = "Albus",
            LastName = "Dumbledore",
            Patronymic = "Percival",
            Birthdate = new DateTime(1881, 8, 3),
            City = "London",
            KnownMagicSkills = ["Transfiguration", "Legilimency"]
        },
        new Wizard
        {
            Id = 2,
            FirstName = "Harry",
            LastName = "Potter",
            Patronymic = "James",
            Birthdate = new DateTime(1980, 7, 31),
            City = "Hogsmeade",
            KnownMagicSkills = ["Invisibility", "Expelliarmus"]
        },
        new Wizard
        {
            Id = 3,
            FirstName = "Hermione",
            LastName = "Granger",
            Patronymic = "Jean",
            Birthdate = new DateTime(1979, 9, 19),
            City = "London",
            KnownMagicSkills = ["TimeTravel", "Charms"]
        }
    };
}