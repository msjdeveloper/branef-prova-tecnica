namespace CompanySystem.Contracts.Company.UpdateCompany;

public record UpdateCompanyResponse(
    Guid Id,
    string Cnpj,
    string CompanyName,
    string BusinessName,
    int Size);
