namespace CompanySystem.Contracts.Company.UpdateCompany;

public record UpdateCompanyRequest(
    Guid Id,
    string Cnpj,
    string CompanyName,
    string BusinessName,
    int Size);
