using CompanySystem.Application.Common.Validators;
using FluentValidation;

namespace CompanySystem.Application.CompanyApplication.Queries.GetCompanyById;

public class GetCompanyByIdQueryValidator : AbstractValidator<GetCompanyByIdQuery>
{
    public GetCompanyByIdQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .Must(ApplicationValidator.BeAValidGuid);
    }
}
