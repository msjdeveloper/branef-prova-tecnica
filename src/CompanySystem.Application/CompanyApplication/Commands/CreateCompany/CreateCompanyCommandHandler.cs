using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.Enums;
using CompanySystem.Domain.CompanyAggregate.Errors;
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
        var company = await _companyRepository.GetByCnpjAsync(command.Cnpj);

        if (company is not null)
        {
            return CompanyErrors.CompanyAlreadyExists;
        }

        var companyCreated = Company.Create(command.Cnpj, command.CompanyName, command.BusinessName, CompanySize.FromValue(command.Size));
        return companyCreated;
    }
}
