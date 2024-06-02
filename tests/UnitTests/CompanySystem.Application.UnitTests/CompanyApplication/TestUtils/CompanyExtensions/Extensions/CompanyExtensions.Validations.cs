using CompanySystem.Application.CompanyApplication.Commands.CreateCompany;
using CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;
using CompanySystem.Application.CompanyApplication.Queries.GetCompanyById;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.Enums;
using FluentAssertions;

namespace CompanySystem.Application.UnitTests.CompanyApplication.TestUtils.CompanyExtensions.Extensions;

public static partial class CompanyExtensions
{
    public static void ValidateCreateFrom(this Company company, CreateCompanyCommand command)
    {
        company.Cnpj.Should().Be(command.Cnpj);
        company.CompanyName.Should().Be(command.CompanyName);
        company.BusinessName.Should().Be(command.BusinessName);
        company.Size.Should().Be(CompanySize.FromValue(command.Size));
    }

    public static void ValidateUpdateFrom(this Company company, UpdateCompanyCommand command)
    {
        company.CompanyName.Should().Be(command.CompanyName);
        company.Size.Should().Be(CompanySize.FromValue(command.Size));
    }

    public static void ValidateGetCompanyById(this Company company, GetCompanyByIdQuery query)
    {
        company.Id.Should().Be(query.Id);
    }
}
