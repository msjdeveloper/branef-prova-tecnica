using ErrorOr;

namespace CompanySystem.Domain.CompanyAggregate.Errors;

public static class CompanyErrors
{
    public static Error CompanyNotFound => Error.NotFound(
        code: "Onboarding.CompanyNotFound",
        description: "Company Not Found");

    public static Error CompanyAlreadyExists => Error.Validation(
        code: "Company.CompanyAlreadyExists",
        description: "Company already exists");

    public static Error TenantCreationFailed => Error.Validation(
        code: "Company.TenantCreationFailed",
        description: "Tenant creation failed");

    public static Error SysAccountUnauthorized => Error.Validation(
        code: "Company.SysAccountUnauthorized",
        description: "SysAccount Unauthorized");

}