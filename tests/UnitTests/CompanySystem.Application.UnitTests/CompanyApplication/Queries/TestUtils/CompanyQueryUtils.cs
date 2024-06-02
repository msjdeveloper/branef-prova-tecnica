using CompanySystem.Application.CompanyApplication.Queries.GetCompanyById;
using CompanySystem.Application.UnitTests.CompanyApplication.TestUtils.Constants;

namespace CompanySystem.Application.UnitTests.CompanyApplication.Queries.TestUtils;

public static class CompanyQueryUtils
{
    public static GetCompanyByIdQuery GetQuery() =>
        new GetCompanyByIdQuery(Constants.Company.Id.Value);
}
