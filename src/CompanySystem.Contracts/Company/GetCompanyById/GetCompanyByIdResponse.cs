namespace CompanySystem.Contracts.Company.GetCompanyById;

public record GetCompanyByIdResponse(
    Guid Id,
    string Cnpj,
    string CompanyName,
    string BusinessName,
    int Size);