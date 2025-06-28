using FluentAssertions;
using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.DataAccess.Data;
using Magics.Application.DataAccess.Wizards.Entity;
using Magics.Application.DataAccess.Wizards.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Magics.Application.DataAccess.UnitTests.Wizards;

public class GetWizardsByFilterTests
{
    private DbContextOptions<MagicsDbContext> CreateNewContextOptions()
    {
        return new DbContextOptionsBuilder<MagicsDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // уникальное имя
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
    }

    private List<WizardEntity> GetTestData() => new()
    {
        new WizardEntity()
        {
            Id = 1,
            FirstName = "True",
            LastName = "True",
            Patronymic = null,
            Birthdate = default,
            City = "Msk",
            KnownMagicSkills = ["magic skill1"]
        },
        new WizardEntity()
        {
            Id = 2,
            FirstName = "True",
            LastName = "False",
            Patronymic = null,
            Birthdate = default,
            City = "Spb",
            KnownMagicSkills = ["magic skill2"]
        },
        new WizardEntity()
        {
            Id = 3,
            FirstName = "False",
            LastName = "False",
            Patronymic = null,
            Birthdate = default,
            City = "Ekb",
            KnownMagicSkills = ["magic skill3"]
        }
    };

    [Fact]
    public async Task WhenFilteredByOneField_ReturnsMatchingWizards()
    {
        var options = CreateNewContextOptions();
        var data = GetTestData();

        var expected = new List<Wizard>()
        {
            new Wizard
            {
                Id = 1,
                FirstName = "True",
                LastName = "True",
                Patronymic = null,
                Birthdate = default,
                City = "Msk",
                KnownMagicSkills = ["magic skill1"]
            },
            new Wizard
            {
                Id = 2,
                FirstName = "True",
                LastName = "False",
                Patronymic = null,
                Birthdate = default,
                City = "Spb",
                KnownMagicSkills = ["magic skill2"]
            },
        };

        var filter = new WizardFilter()
        {
            FirstName = "True"
        };

        await using (var context = new MagicsDbContext(options))
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }

        List<Wizard> result;

        await using (var context = new MagicsDbContext(options))
        {
            IWizardRepository repository = new WizardRepository(context);
            result = await repository.GetByFilterAsync(filter);
        }

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task WhenFilteredByAllField_ReturnsMatchingWizards()
    {
        var options = CreateNewContextOptions();
        var data = GetTestData();

        var expected = new List<Wizard>()
        {
            new Wizard
            {
                Id = 1,
                FirstName = "True",
                LastName = "True",
                Patronymic = null,
                Birthdate = default,
                City = "Msk",
                KnownMagicSkills = ["magic skill1"]
            }
        };

        var filter = new WizardFilter()
        {
            Id = 1,
            FirstName = "True",
            LastName = "True",
            Patronymic = null,
            Birthdate = default,
            City = "Msk",
            KnownMagicSkills = ["magic skill1"]
        };

        await using (var context = new MagicsDbContext(options))
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }

        List<Wizard> result;

        await using (var context = new MagicsDbContext(options))
        {
            IWizardRepository repository = new WizardRepository(context);
            result = await repository.GetByFilterAsync(filter);
        }

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task WhenFilterIsEmpty_ReturnsAllWizards()
    {
        var options = CreateNewContextOptions();
        var data = GetTestData();

        var expected = new List<Wizard>()
        {
            new Wizard
            {
                Id = 1,
                FirstName = "True",
                LastName = "True",
                Patronymic = null,
                Birthdate = default,
                City = "Msk",
                KnownMagicSkills = ["magic skill1"]
            },
            new Wizard
            {
                Id = 2,
                FirstName = "True",
                LastName = "False",
                Patronymic = null,
                Birthdate = default,
                City = "Spb",
                KnownMagicSkills = ["magic skill2"]
            },
            new Wizard
            {
                Id = 3,
                FirstName = "False",
                LastName = "False",
                Patronymic = null,
                Birthdate = default,
                City = "Ekb",
                KnownMagicSkills = ["magic skill3"]
            }
        };

        var filter = new WizardFilter();

        await using (var context = new MagicsDbContext(options))
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }

        List<Wizard> result;

        await using (var context = new MagicsDbContext(options))
        {
            IWizardRepository repository = new WizardRepository(context);
            result = await repository.GetByFilterAsync(filter);
        }

        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task WhenFilterIsInvalid_ReturnsEmptyList()
    {
        var options = CreateNewContextOptions();
        var data = GetTestData();

        var expected = new List<Wizard>();

        var filter = new WizardFilter()
        {
            FirstName = "False",
            LastName = "True"
        };

        await using (var context = new MagicsDbContext(options))
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }

        List<Wizard> result;

        await using (var context = new MagicsDbContext(options))
        {
            IWizardRepository repository = new WizardRepository(context);
            result = await repository.GetByFilterAsync(filter);
        }

        result.Should().BeEquivalentTo(expected);
    }
}