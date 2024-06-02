using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;
using CompanySystem.Application.UnitTests.CompanyApplication.Commands.TestUtils;
using CompanySystem.Application.UnitTests.CompanyApplication.TestUtils.CompanyExtensions.Extensions;
using CompanySystem.Domain.CompanyAggregate;
using FluentAssertions;
using CompanySystem.Application.UnitTests.CompanyApplication.TestUtils;
using Moq;

namespace CompanySystem.Application.UnitTests.CompanyApplication.Commands.UpdateCompany;

public class UpdateCompanyCommandHandlerTest
{
    private readonly UpdateCompanyCommandHandler _handler;
    private readonly Mock<ICompanyRepository> _companyRepositoryMock;

    public UpdateCompanyCommandHandlerTest()
    {
        _companyRepositoryMock = new Mock<ICompanyRepository>();
        _handler = new UpdateCompanyCommandHandler(_companyRepositoryMock.Object);
    }

    [Theory]
    [MemberData(nameof(ValideUpdateCompanyCommands))]

    public async Task Handle_UpdateCompanyCommand_ShouldReturnUpdatedCompany(UpdateCompanyCommand command)
    {
        // Arrange
        var company = new CompanyBuilder().Build();
        _companyRepositoryMock.Setup(c => c.GetByIdAsync(command.Id)).ReturnsAsync(company);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateUpdateFrom(command);
        _companyRepositoryMock.Verify(c => c.UpdateAsync(result.Value), Times.Once);
    }


    [Theory]
    [MemberData(nameof(ValideUpdateCompanyCommands))]
    public async Task Handle_UpdateCompanyCommand_ShouldReturnErrorWhenCompanyDoesNotExists(UpdateCompanyCommand command)
    {
        // Arrange
        _companyRepositoryMock.Setup(c => c.GetByIdAsync(command.Id)).ReturnsAsync((Company?)null);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsError.Should().BeTrue();
        _companyRepositoryMock.Verify(c => c.UpdateAsync(result.Value), Times.Never);
    }

    public static IEnumerable<object[]> ValideUpdateCompanyCommands()
    {
        yield return new object[] { CompanyCommandUtils.UpdateCommand() };
    }


}
