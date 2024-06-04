using CompanySystem.Domain.CompanyAggregate;

namespace CompanySystem.Application.CompanyApplication.Common;

public record GetCompaniesResult(
    List<Company> Company
);
