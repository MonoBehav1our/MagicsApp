using FluentAssertions;
using Magics.Application.AppServices.Contracts.Infrastructure.Exceptions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Models;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Contracts.Magics.Requests;
using Magics.Application.AppServices.Contracts.Wizards.Models;
using Magics.Application.AppServices.Contracts.Wizards.Repository;
using Magics.Application.AppServices.Magics.Handlers;
using NSubstitute;

namespace Magics.Application.AppServices.UnitTests.Magics;

public class CreateMagicHandlerTests
{
    
    [Fact]
    public async Task WithCorrectData_Success()
    {
        var filter = new WizardFilter { Id = 1 };
        var wizard = new Wizard()
        {
            Id = 1,
            FirstName = "testData",
            LastName = "testData",
            Birthdate = default,
            City = "testData",
            KnownMagicSkills = []
        };
        var request = new CreateMagicInternalRequest
        {
            Wizard_Id = 1,
            Salary = 100,
            ExperienceYears = 1,
            DesiredSkill = "DesiredSkill",
            CreatedAt = DateTime.UtcNow
        };
        
        var wizardRepository = Substitute.For<IWizardRepository>();
        wizardRepository
            .GetByFilterAsync(Arg.Is<WizardFilter>(f => f.Id == request.Wizard_Id))
            .Returns(new List<Wizard> { wizard });
        
        var magicRepository = Substitute.For<IMagicRepository>();
        var handler = new CreateMagicHandler(magicRepository, wizardRepository);
        
        await handler.Handle(request);
        await magicRepository.Received(1).CreateAsync(Arg.Is<Magic>(m =>
            m.WizardId == request.Wizard_Id &&
            m.Salary == request.Salary &&
            m.ExperienceYears == request.ExperienceYears &&
            m.DesiredSkill == request.DesiredSkill &&
            m.Status == MagicStatus.Pending &&
            m.CreatedAt == request.CreatedAt.Value.ToUniversalTime()
        ));
    }

    [Fact]
    public async Task WithNotExistWizard_ThrowNotFoundException()
    {
        var filter = new WizardFilter { Id = 999 };
        var wizardRepository = Substitute.For<IWizardRepository>();
        wizardRepository.GetByFilterAsync(filter).Returns(new List<Wizard> { });
        
        var request = new CreateMagicInternalRequest
        {
            Wizard_Id = 1,
            Salary = 100,
            ExperienceYears = 1,
            DesiredSkill = "DesiredSkill",
            CreatedAt = DateTime.UtcNow
        };
        
        var magicRepository = Substitute.For<IMagicRepository>();
        var handler = new CreateMagicHandler(magicRepository, wizardRepository);
        
        var act = async () => await handler.Handle(request);
        await act.Should().ThrowAsync<NotFoundException>();
    } 
}