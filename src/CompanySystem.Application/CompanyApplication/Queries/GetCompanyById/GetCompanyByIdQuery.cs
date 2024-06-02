using MediatR;
using ErrorOr;
using CompanySystem.Application.CompanyApplication.Common;

namespace CompanySystem.Application.CompanyApplication.Queries.GetCompanyById;

public record GetCompanyByIdQuery(
    Guid Id) : IRequest<ErrorOr<GetCompanyByIdResult>>;
