using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.Errors;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;

public class UpdateCompanyCommandHandler
    : IRequestHandler<UpdateCompanyCommand, ErrorOr<Company>>
{
    private readonly ICompanyRepository _companyRepository;
    public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    public async Task<ErrorOr<Company>> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
