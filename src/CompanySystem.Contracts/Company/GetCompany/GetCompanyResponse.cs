namespace CompanySystem.Contracts.Company.GetCompany;

public record GetCompanyResponse(
    Guid Id,
    string Cnpj,
    string CompanyName,
    string BusinessName,
    int Size);