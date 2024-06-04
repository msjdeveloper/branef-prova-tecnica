using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Application.CompanyApplication.Common;
using CompanySystem.Domain.CompanyAggregate.Errors;
using ErrorOr;
using MediatR;

namespace CompanySystem.Application.CompanyApplication.Queries.GetCompanies
{
    public class GetCompaniesQueryHandler
        : IRequestHandler<GetCompaniesQuery, ErrorOr<GetCompaniesResult>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ErrorOr<GetCompaniesResult>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetCompanies();

            if (companies is null)
            {
                return CompanyErrors.CompanyNotFound;
            }
            
            return new GetCompaniesResult(companies);
        }
    }
}
