using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.DataAccess.Data;
using Magics.Application.DataAccess.Magics.Entity;
using Magics.Application.DataAccess.Magics.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Magics.Application.DataAccess.UnitTests.Magics;

public class GetAllMagicsByWizardIdTests
{
    private DbContextOptions<MagicsDbContext> CreateNewContextOptions()
    {
        return new DbContextOptionsBuilder<MagicsDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // уникальное имя
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
    }

    [Fact]
    public async Task WithCorrectId_ReturnAll()
    {
        var options = CreateNewContextOptions();
        var data = GetData();

        var expected = new List<Magic>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                WizardId = 1,
                Salary = 100,
                ExperienceYears = 1,
                DesiredSkill = "Magic skill1",
                Status = MagicStatus.Pending,
                CreatedAt = default
            },
            new()
            {
                Id = Guid.NewGuid(),
                WizardId = 1,
                Salary = 100,
                ExperienceYears = 2,
                DesiredSkill = "Magic skill2",
                Status = MagicStatus.Pending,
                CreatedAt = default
            },
            new()
            {
                Id = Guid.NewGuid(),
                WizardId = 1,
                Salary = 100,
                ExperienceYears = 3,
                DesiredSkill = "Magic skill3",
                Status = MagicStatus.Pending,
                CreatedAt = default
            },
        };

        List<Magic> result;

        await using (var context = new MagicsDbContext(options))
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }

        await using (var context = new MagicsDbContext(options))
        {
            IMagicRepository repository = new MagicRepository(context);
            result = await repository.GetWizardMagicsAsync(1);
        }

        result.Should().BeEquivalentTo(expected, 
            eqOptions => eqOptions.Excluding(magic => magic.Id));
    }

    [Fact]
    public async Task WithCorrectId_ReturnPartData()
    {
        var options = CreateNewContextOptions();
        var data = GetData();

        var expected = new List<Magic>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                WizardId = 99,
                Salary = 100,
                ExperienceYears = 10,
                DesiredSkill = "Magic skill4",
                Status = MagicStatus.Pending,
                CreatedAt = default
            },
        };

        List<Magic> result;

        await using (var context = new MagicsDbContext(options))
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }

        await using (var context = new MagicsDbContext(options))
        {
            IMagicRepository repository = new MagicRepository(context);
            result = await repository.GetWizardMagicsAsync(99);
        }

        result.Should().BeEquivalentTo(expected, 
            eqOptions => eqOptions.Excluding(magic => magic.Id));
    }

    [Fact]
    public async Task WithUnCorrectId_ReturnEmptyList()
    {
        var options = CreateNewContextOptions();
        var data = GetData();

        List<Magic> result;

        await using (var context = new MagicsDbContext(options))
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
        }

        await using (var context = new MagicsDbContext(options))
        {
            IMagicRepository repository = new MagicRepository(context);
            result = await repository.GetWizardMagicsAsync(-1);
        }

        result.Count.Should().Be(0);
    }

    private List<MagicEntity> GetData()
    {
        return
        [
            new MagicEntity
            {
                Id = Guid.NewGuid(),
                WizardId = 1,
                Salary = 100,
                ExperienceYears = 1,
                DesiredSkill = "Magic skill1",
                Status = MagicStatus.Pending,
                CreatedAt = default
            },
            new MagicEntity
            {
                Id = Guid.NewGuid(),
                WizardId = 1,
                Salary = 100,
                ExperienceYears = 2,
                DesiredSkill = "Magic skill2",
                Status = MagicStatus.Pending,
                CreatedAt = default
            },

            new MagicEntity
            {
                Id = Guid.NewGuid(),
                WizardId = 1,
                Salary = 100,
                ExperienceYears = 3,
                DesiredSkill = "Magic skill3",
                Status = MagicStatus.Pending,
                CreatedAt = default
            },

            new MagicEntity
            {
                Id = Guid.NewGuid(),
                WizardId = 99,
                Salary = 100,
                ExperienceYears = 10,
                DesiredSkill = "Magic skill4",
                Status = MagicStatus.Pending,
                CreatedAt = default
            }
        ];
    }
}