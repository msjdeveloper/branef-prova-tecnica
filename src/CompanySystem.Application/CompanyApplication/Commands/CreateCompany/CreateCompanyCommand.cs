using ErrorOr;
using MediatR;
using CompanySystem.Domain.CompanyAggregate;

namespace CompanySystem.Application.CompanyApplication.Commands.CreateCompany;

public record CreateCompanyCommand
(
    string Cnpj,
    string CompanyName,
    string BusinessName,
    int Size
) : IRequest<ErrorOr<Company>>;
