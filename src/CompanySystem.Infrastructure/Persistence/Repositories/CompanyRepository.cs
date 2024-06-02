using CompanySystem.Application.Common.Interfaces.Persistence;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;
using CompanySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem.Infrastructure.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly CompanySystemDbContext _dbContext;

    public CompanyRepository(CompanySystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Company company)
    {
        _dbContext.Add(company);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Company?> GetByIdAsync(Guid id)
    {
        return await _dbContext
            .Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == CompanyId.Create(id));
    }

    public async Task<Company?> GetByCnpjAsync(string cnpj)
    {
        return await _dbContext
            .Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Cnpj == cnpj);
    }

    public async Task UpdateAsync(Company company)
    {
        _dbContext.Update(company);
        await _dbContext.SaveChangesAsync();
    }
}
