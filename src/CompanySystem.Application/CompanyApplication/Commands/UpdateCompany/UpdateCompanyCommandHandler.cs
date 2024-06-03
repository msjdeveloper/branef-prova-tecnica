using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.Enums;
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
        var company = await _companyRepository.GetByIdAsync(command.Id);
        
        if (company is null)
        {
            return CompanyErrors.CompanyNotFound;
        }

        var companyUpdated = Company.Update(
            CompanyId.Create(command.Id), 
            company.Cnpj, 
            command.CompanyName, 
            company.BusinessName, 
            CompanySize.FromValue(command.Size),
            company.CreatedAt);

        return companyUpdated;

    }
}
