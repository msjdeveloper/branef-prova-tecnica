using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.Enums;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;

namespace CompanySystem.Application.UnitTests.CompanyApplication.TestUtils;

public class CompanyBuilder
{
    private CompanyId _id = Constants.Constants.Company.Id;
    private string _cnpj = Constants.Constants.Company.Cnpj;
    private string _companyName = Constants.Constants.Company.CompanyName;
    private string _businessName = Constants.Constants.Company.BusinessName;
    private CompanySize _size = Constants.Constants.Company.Size;

    public CompanyBuilder WithId(CompanyId id)
    {
        _id = id;
        return this;
    }

    public Company Build()
    {
        var company = Company.Create(
            _cnpj,
            _companyName,
            _businessName,
            _size);

        company.SetId(_id);
        return company;
    }
}
