using FluentAssertions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Magics.Handlers;
using NSubstitute;

namespace Magics.Application.AppServices.UnitTests.Magics;

public class GetWizardMagicsHandlerTests
{
    [Fact]
    public async Task WithValidID_ReturnAllMagics()
    {
        var data = GetData();

        var magicRepository = Substitute.For<IMagicRepository>();
        magicRepository.GetWizardMagicsAsync(1).Returns(data);

        IGetWizardMagics handler = new GetWizardMagics(magicRepository);
        var result = await handler.Handle(1);

        await magicRepository.Received(1).GetWizardMagicsAsync(1);
        result.Skills.Should().BeEquivalentTo(data, options =>
            options.Excluding(m => m.Id));
    }

    [Fact]
    public async Task WithValidID_ReturnOneMagic()
    {
        var data = GetData().GetRange(2, 1);

        var magicRepository = Substitute.For<IMagicRepository>();
        magicRepository.GetWizardMagicsAsync(999).Returns(data);

        IGetWizardMagics handler = new GetWizardMagics(magicRepository);
        var result = await handler.Handle(999);

        await magicRepository.Received(1).GetWizardMagicsAsync(999);
        result.Skills.Should().BeEquivalentTo(data, options =>
            options.Excluding(m => m.Id));
    }

    [Fact]
    public async Task WithInvalidID_ReturnEmptyList()
    {
        var magicRepository = Substitute.For<IMagicRepository>();
        magicRepository.GetWizardMagicsAsync(999).Returns(new List<Magic>());

        IGetWizardMagics handler = new GetWizardMagics(magicRepository);
        var result = await handler.Handle(999);

        await magicRepository.Received(1).GetWizardMagicsAsync(999);
        result.Skills.Should().BeEmpty();
    }

    private List<Magic> GetData() => new List<Magic>
    {
        new()
        {
            Id = Guid.NewGuid(),
            WizardId = 1,
            Salary = 100,
            ExperienceYears = 1,
            DesiredSkill = "Desired skill1",
            Status = MagicStatus.Pending,
            CreatedAt = default
        },
        new()
        {
            Id = Guid.NewGuid(),
            WizardId = 1,
            Salary = 100,
            ExperienceYears = 2,
            DesiredSkill = "Desired skill2",
            Status = MagicStatus.Pending,
            CreatedAt = default
        },
        new()
        {
            Id = Guid.NewGuid(),
            WizardId = 1,
            Salary = 100,
            ExperienceYears = 3,
            DesiredSkill = "Desired skill3",
            Status = MagicStatus.Pending,
            CreatedAt = default
        },
    };
}