namespace CompanySystem.Contracts.Company.CreateCompany;

public record CreateCompanyResponse(
    Guid Id,
    string Cnpj,
    string CompanyName,
    string BusinessName,
    int Size);
