using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.DataAccess.Data;
using Magics.Application.DataAccess.Magics.Entity;
using Magics.Application.DataAccess.Magics.Repository;
using Magics.Application.AppServices.Contracts.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Magics.Application.DataAccess.UnitTests.Magics;

public class GetMagicStatusTests
{
    private DbContextOptions<MagicsDbContext> CreateOptions()
    {
        return new DbContextOptionsBuilder<MagicsDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
    }

    [Fact]
    public async Task WithCorrectId_Success()
    {
        var id = Guid.NewGuid();
        var entity = new MagicEntity
        {
            Id = id,
            WizardId = 1,
            Salary = 100,
            ExperienceYears = 1,
            DesiredSkill = "skill",
            Status = MagicStatus.Rejected,
            CreatedAt = default
        };

        var options = CreateOptions();
        await using (var ctx = new MagicsDbContext(options))
        {
            await ctx.AddAsync(entity);
            await ctx.SaveChangesAsync();
        }

        await using (var ctx = new MagicsDbContext(options))
        {
            var repo = new MagicRepository(ctx);
            var result = await repo.GetStatusAsync(id);
            result.Should().Be(MagicStatus.Rejected);
        }
    }

    [Fact]
    public async Task WithInvalidId_ThrowsNotFound()
    {
        var options = CreateOptions();
        await using (var ctx = new MagicsDbContext(options))
        {
        }

        await using (var ctx = new MagicsDbContext(options))
        {
            var repo = new MagicRepository(ctx);
            Func<Task> act = () => repo.GetStatusAsync(Guid.NewGuid());
            await act.Should().ThrowAsync<NotFoundException>();
        }
    }
}