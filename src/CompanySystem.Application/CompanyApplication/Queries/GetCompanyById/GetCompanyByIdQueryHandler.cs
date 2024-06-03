using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Application.CompanyApplication.Common;
using CompanySystem.Domain.CompanyAggregate.Errors;
using ErrorOr;
using MediatR;

namespace CompanySystem.Application.CompanyApplication.Queries.GetCompanyById
{
    public class GetCompanyByIdQueryHandler
        : IRequestHandler<GetCompanyByIdQuery, ErrorOr<GetCompanyByIdResult>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyByIdQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ErrorOr<GetCompanyByIdResult>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            if (company is null)
            {
                return CompanyErrors.CompanyNotFound;
            }

            return new GetCompanyByIdResult(company);
        }
    }
}
