using CompanySystem.Domain.CompanyAggregate.Enums;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;
using CompanySystem.Domain.Models;

namespace CompanySystem.Domain.CompanyAggregate;

public class Company : AggregateRoot<CompanyId>
{
    public string Cnpj { get; private set; }
    public string CompanyName { get; private set; }
    public string BusinessName { get; private set; }
    public CompanySize Size { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Company(
        CompanyId id,
        string cnpj,
        string companyName,
        string businessName,
        CompanySize size,
        DateTime createdAt,
        DateTime? updatedAt = null) : base(id)
    {
        Cnpj = cnpj;
        CompanyName = companyName;
        BusinessName = businessName;
        Size = size;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Company Create(
        string cnpj,
        string companyName,
        string businessName,
        CompanySize size)
    {
        return new Company(
            CompanyId.CreateUnique(),
            cnpj,
            companyName,
            businessName,
            size,
            DateTime.UtcNow);
    }

    public static Company Update(
        CompanyId id,
        string cnpj,
        string companyName,
        string businessName,
        CompanySize size,
        DateTime createdAt)
    {
        return new Company(
            id,
            cnpj,
            companyName,
            businessName,
            size,
            createdAt,
            DateTime.UtcNow);
    }

    public static Company Delete(
        CompanyId id,
        string cnpj,
        string companyName,
        string businessName,
        CompanySize size,
        DateTime createdAt)
    {
        return new Company(
            id,
            cnpj,
            companyName,
            businessName,
            size,
            createdAt,
            DateTime.UtcNow);
    }
    
    public void SetId(CompanyId id)
    {
        Id = id;
    }

#pragma warning disable CS8618
    private Company()
    {
    }
#pragma warning restore CS8618
}
