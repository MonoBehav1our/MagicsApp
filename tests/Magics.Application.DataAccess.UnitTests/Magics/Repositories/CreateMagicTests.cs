using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.DataAccess.Data;
using Magics.Application.DataAccess.Magics.Repository;
using Magics.Application.DataAccess.Wizards.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Magics.Application.DataAccess.UnitTests.Magics;

public class CreateMagicTests
{
    private readonly DbContextOptions<MagicsDbContext> _dbContextOptions;

    public CreateMagicTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<MagicsDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabaseForClient")
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        using var context = new MagicsDbContext(_dbContextOptions);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    [Fact]
    public async Task WithValidData_Success()
    {
        var wizard = new WizardEntity
        {
            Id = 10,
            FirstName = "Name",
            LastName = "LastName",
            Patronymic = null,
            Birthdate = default,
            City = "City",
            KnownMagicSkills =
            [
                "Known Magic Skill",
            ]
        };
        var model = new Magic
        {
            WizardId = 10,
            Salary = 100,
            ExperienceYears = 1,
            DesiredSkill = "magic",
            Status = MagicStatus.Pending,
            CreatedAt = default
        };
        var expected = new List<Magic>()
        {
            new Magic
            {
                WizardId = 10,
                Salary = 100,
                ExperienceYears = 1,
                DesiredSkill = "magic",
                Status = MagicStatus.Pending,
                CreatedAt = default
            }
        };

        await using (var context = new MagicsDbContext(_dbContextOptions))
        {
            await context.wizards.AddAsync(wizard);
            await context.SaveChangesAsync();

            IMagicRepository repository = new MagicRepository(context);
            await repository.CreateAsync(model);
        }

        await using (var context = new MagicsDbContext(_dbContextOptions))
        {
            expected.Should().BeEquivalentTo(context.magics, options =>
                options.Excluding(m => m.Id));
        }
    }

    [Fact]
    public async Task WithNullData_Error()
    {
        var wizard = new WizardEntity
        {
            Id = 10,
            FirstName = "Name",
            LastName = "LastName",
            Patronymic = null,
            Birthdate = default,
            City = "City",
            KnownMagicSkills =
            [
                "Known Magic Skill",
            ]
        };
        Magic model = null;

        await using var context = new MagicsDbContext(_dbContextOptions);
        await context.wizards.AddAsync(wizard);
        await context.SaveChangesAsync();

        IMagicRepository repository = new MagicRepository(context);
        var act = async () => await repository.CreateAsync(model);
        await act.Should().ThrowAsync<NullReferenceException>();
    }
}