using CompanySystem.Domain.Models;

namespace CompanySystem.Domain.CompanyAggregate.ValueObjects;

public class CompanyId : ValueObject
{
    public Guid Value { get; }

    private CompanyId(Guid value)
    {
        Value = value;
    }

    public static CompanyId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CompanyId Create(Guid value)
    {
        return new CompanyId(value);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
