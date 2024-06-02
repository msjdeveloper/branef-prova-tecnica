using ErrorOr;
using MediatR;
using CompanySystem.Domain.CompanyAggregate;

namespace CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;

public record UpdateCompanyCommand(
    Guid Id,
    string CompanyName,
    int Size) : IRequest<ErrorOr<Company>>;
