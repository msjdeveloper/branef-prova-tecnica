using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Domain.CompanyAggregate;
using ErrorOr;
using MediatR;

namespace CompanySystem.Application.CompanyApplication.Commands.CreateCompany;

public class CreateCompanyCommandHandler
    : IRequestHandler<CreateCompanyCommand, ErrorOr<Company>>
{
    private readonly ICompanyRepository _companyRepository;

    public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<ErrorOr<Company>> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
