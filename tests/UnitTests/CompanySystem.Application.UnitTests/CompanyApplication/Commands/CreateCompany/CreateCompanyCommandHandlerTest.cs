using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Application.CompanyApplication.Commands.CreateCompany;
using CompanySystem.Application.UnitTests.CompanyApplication.Commands.TestUtils;
using CompanySystem.Application.UnitTests.CompanyApplication.TestUtils;
using CompanySystem.Application.UnitTests.CompanyApplication.TestUtils.CompanyExtensions.Extensions;
using FluentAssertions;
using Moq;

namespace CompanySystem.Application.UnitTests.CompanyApplication.Commands.CreateCompany;

public class CreateCompanyCommandHandlerTest
{
    private readonly CreateCompanyCommandHandler _handler;
    private readonly Mock<ICompanyRepository> _companyRepositoryMock;

    public CreateCompanyCommandHandlerTest()
    {
        _companyRepositoryMock = new Mock<ICompanyRepository>();
        _handler = new CreateCompanyCommandHandler(_companyRepositoryMock.Object);
    }

    [Theory]
    [MemberData(nameof(ValideCreateCompanyCommands))]

    public async Task Handle_CreateCompanyCommand_ShouldReturnCreatedCompany(CreateCompanyCommand command)
    {
        // Act
        var result = await _handler.Handle(command, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreateFrom(command);
        _companyRepositoryMock.Verify(c => c.AddAsync(result.Value), Times.Once);
    }

    [Theory]
    [MemberData(nameof(ValideCreateCompanyCommands))]
    public async Task Handle_CreateCompanyCommand_ShouldReturnErrorWhenCompanyAlreadyExists(CreateCompanyCommand command)
    {
        // Arrange
        var company = new CompanyBuilder().Build();
        _companyRepositoryMock.Setup(c => c.GetByCnpjAsync(command.Cnpj)).ReturnsAsync(company);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsError.Should().BeTrue();
        _companyRepositoryMock.Verify(c => c.AddAsync(result.Value), Times.Never);
    }

    public static IEnumerable<object[]> ValideCreateCompanyCommands()
    {
        yield return new object[] { CompanyCommandUtils.CreateCommand() };
    }
}