using CompanySystem.Application.Common.Validators;
using CompanySystem.Domain.CompanyAggregate.Enums;
using FluentValidation;

namespace CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .Must(ApplicationValidator.BeAValidGuid);

        RuleFor(c => c.CompanyName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.Size)
            .NotEmpty()
            .Must(ApplicationValidator.BeAValidEnumValue<CompanySize>);
    }
}
