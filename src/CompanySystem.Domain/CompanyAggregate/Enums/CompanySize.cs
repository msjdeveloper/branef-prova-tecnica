using Ardalis.SmartEnum;

namespace CompanySystem.Domain.CompanyAggregate.Enums;

public class CompanySize : SmartEnum<CompanySize>
{
    public CompanySize(string name, int value) : base(name, value) { }

    public static readonly CompanySize Small = new CompanySize(nameof(Small), 1);
    public static readonly CompanySize Medium = new CompanySize(nameof(Medium), 2);
    public static readonly CompanySize Large = new CompanySize(nameof(Large), 3);
}
