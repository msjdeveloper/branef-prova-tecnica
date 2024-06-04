using MediatR;
using ErrorOr;
using CompanySystem.Application.CompanyApplication.Common;

namespace CompanySystem.Application.CompanyApplication.Queries.GetCompanies;

public record GetCompaniesQuery() : IRequest<ErrorOr<GetCompaniesResult>>;
