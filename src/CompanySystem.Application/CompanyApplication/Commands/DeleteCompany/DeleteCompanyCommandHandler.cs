using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.Enums;
using CompanySystem.Domain.CompanyAggregate.Errors;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace CompanySystem.Application.CompanyApplication.Commands.DeleteCompany;

public class DeleteCompanyCommandHandler
    : IRequestHandler<DeleteCompanyCommand, ErrorOr<bool>>
{
    private readonly ICompanyRepository _companyRepository;

    public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(command.Id);

        if (company is null)
        {
            return CompanyErrors.CompanyNotFound;
        }

        var companyDeleted = Company.Delete(
            CompanyId.Create(command.Id),
            company.Cnpj,
            company.CompanyName,
            company.BusinessName,
            company.Size,
            company.CreatedAt);
        
        await _companyRepository.DeleteAsync(companyDeleted);

        return true;
    }
}
