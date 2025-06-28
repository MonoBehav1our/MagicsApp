using FluentAssertions;
using Magics.Application.AppServices.Contracts.Infrastructure.Exceptions;
using Magics.Application.AppServices.Contracts.Magics.Enums;
using Magics.Application.AppServices.Contracts.Magics.Handlers;
using Magics.Application.AppServices.Contracts.Magics.Repository;
using Magics.Application.AppServices.Magics.Handlers;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Magics.Application.AppServices.UnitTests.Magics.Handlers;

public class GetMagicStatusHandlerTests
{
    [Fact]
    public async Task ValidId_ReturnsCorrectStatus()
    {
        var id = Guid.NewGuid();
        var repo = Substitute.For<IMagicRepository>();
        repo.GetStatusAsync(id).Returns(MagicStatus.Approved);

        IGetStatusByIdHandler handler = new GetStatusByIdHandler(repo);

        // Act
        var result = await handler.Handle(id);

        // Assert
        result.Should().Be(MagicStatus.Approved);
    }

    [Fact]
    public async Task InvalidId_ThrowNotFoundException()
    {
        var id = Guid.NewGuid();
        var repo = Substitute.For<IMagicRepository>();
        repo.GetStatusAsync(id).Throws<NotFoundException>();

        IGetStatusByIdHandler handler = new GetStatusByIdHandler(repo);

        // Act
        var act = async () =>  await handler.Handle(id);
        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}