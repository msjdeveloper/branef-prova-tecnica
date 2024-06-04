using CompanySystem.Application.Common.Validators;
using FluentValidation;

namespace CompanySystem.Application.CompanyApplication.Commands.DeleteCompany;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .Must(ApplicationValidator.BeAValidGuid);
    }
}
