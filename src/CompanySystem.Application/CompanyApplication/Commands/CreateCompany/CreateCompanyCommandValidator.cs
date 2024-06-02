using CompanySystem.Application.Common.Validators;
using CompanySystem.Domain.CompanyAggregate.Enums;
using FluentValidation;

namespace CompanySystem.Application.CompanyApplication.Commands.CreateCompany;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.Cnpj)
            .NotEmpty()
            .Length(14)
            .Must(ApplicationValidator.BeAValidCnpj);

        RuleFor(c => c.CompanyName)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(c => c.BusinessName)
            .MaximumLength(200);

        RuleFor(c => c.Size)
            .NotEmpty()
            .Must(ApplicationValidator.BeAValidEnumValue<CompanySize>);
    }
}
