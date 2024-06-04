using MediatR;
using ErrorOr;
using CompanySystem.Domain.CompanyAggregate;

namespace CompanySystem.Application.CompanyApplication.Commands.DeleteCompany;

public record DeleteCompanyCommand(
    Guid Id) : IRequest<ErrorOr<bool>>;
