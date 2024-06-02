using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Application.CompanyApplication.Queries.GetCompanyById;
using CompanySystem.Application.UnitTests.CompanyApplication.Queries.TestUtils;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;
using FluentAssertions;
using CompanySystem.Application.CompanyApplication.Common;
using CompanySystem.Application.UnitTests.CompanyApplication.TestUtils;
using Moq;

namespace CompanySystem.Application.UnitTests.CompanyApplication.Queries.GetCompanyById;

public class GetCompanyByIdQueryHandlerTest
{
    private readonly GetCompanyByIdQueryHandler _handler;
    private readonly Mock<ICompanyRepository> _companyRepositoryMock;

    public GetCompanyByIdQueryHandlerTest()
    {
        _companyRepositoryMock = new Mock<ICompanyRepository>();
        _handler = new GetCompanyByIdQueryHandler(_companyRepositoryMock.Object);
    }

    [Theory]
    [MemberData(nameof(ValideGetCompanyByIdQueries))]
    public async Task Handle_GetCompanyByIdQuery_ShouldReturnCompany(GetCompanyByIdQuery query)
    {
        // Arrange
        var company = new CompanyBuilder().WithId(CompanyId.Create(query.Id)).Build();
        _companyRepositoryMock.Setup(c => c.GetByIdAsync(query.Id)).ReturnsAsync(company);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().BeEquivalentTo(new GetCompanyByIdResult(company));
    }

    [Theory]
    [MemberData(nameof(ValideGetCompanyByIdQueries))]
    public async Task Handle_GetCompanyByIdQuery_ShouldReturnErrorWhenCompanyNotFound(GetCompanyByIdQuery query)
    {
        // Arrange
        _companyRepositoryMock.Setup(c => c.GetByIdAsync(query.Id)).ReturnsAsync((Company?)null);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsError.Should().BeTrue();
        result.Value.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(ValideGetCompanyByIdQueries))]
    public async Task Handle_GetCompanyByIdQuery_ShouldReturnErrorWhenCompanyRepositoryReturnsNull(GetCompanyByIdQuery query)
    {
        // Arrange
        _companyRepositoryMock.Setup(c => c.GetByIdAsync(query.Id)).ReturnsAsync((Company?)null);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsError.Should().BeTrue();
        result.Value.Should().BeNull();
    }

    public static IEnumerable<object[]> ValideGetCompanyByIdQueries()
    {
        yield return new object[] { CompanyQueryUtils.GetQuery() };
    }
}
