using CompanySystem.Domain.CompanyAggregate;

namespace CompanySystem.Application.Common.Interfaces.Persistence;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Task<List<Company>> GetCompanies();
    Task<Company?> GetByIdAsync(Guid id);
    Task<Company?> GetByCnpjAsync(string cnpj);
    Task UpdateAsync(Company company);
    Task DeleteAsync(Company company);
}
