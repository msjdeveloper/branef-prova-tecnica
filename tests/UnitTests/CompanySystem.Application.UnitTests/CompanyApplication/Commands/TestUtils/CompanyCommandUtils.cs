using CompanySystem.Application.CompanyApplication.Commands.CreateCompany;
using CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;
using CompanySystem.Application.UnitTests.CompanyApplication.TestUtils.Constants;

namespace CompanySystem.Application.UnitTests.CompanyApplication.Commands.TestUtils;

public static class CompanyCommandUtils
{
    public static CreateCompanyCommand CreateCommand() =>
        new CreateCompanyCommand(
            Constants.Company.Cnpj,
            Constants.Company.CompanyName,
            Constants.Company.BusinessName,
            Constants.Company.Size);

    public static UpdateCompanyCommand UpdateCommand() =>
        new UpdateCompanyCommand(
            Constants.Company.Id.Value,
            Constants.Company.CompanyName,
            Constants.Company.Size);

}