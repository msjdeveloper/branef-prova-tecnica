namespace CompanySystem.Contracts.Company.CreateCompany;

public record CreateCompanyRequest(
    string Cnpj,
    string CompanyName,
    string BusinessName,
    int Size);