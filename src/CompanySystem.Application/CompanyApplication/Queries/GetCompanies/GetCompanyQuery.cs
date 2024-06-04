using MediatR;
using ErrorOr;
using CompanySystem.Application.CompanyApplication.Common;
using CompanySystem.Domain.CompanyAggregate;

namespace CompanySystem.Application.CompanyApplication.Queries.GetCompanies;

public record GetCompaniesQuery() : IRequest<ErrorOr<List<Company>>>;
