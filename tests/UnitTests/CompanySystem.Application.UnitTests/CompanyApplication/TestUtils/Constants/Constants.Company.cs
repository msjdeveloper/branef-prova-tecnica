using CompanySystem.Domain.CompanyAggregate.Enums;
using CompanySystem.Domain.CompanyAggregate.ValueObjects;

namespace CompanySystem.Application.UnitTests.CompanyApplication.TestUtils.Constants;

public static partial class Constants
{
    public static class Company
    {
        public static readonly CompanyId Id = CompanyId.Create(Guid.NewGuid());
        public const string Cnpj = "12345678901234";
        public const string CompanyName = "Company Name";
        public const string BusinessName = "Business Name";
        public static readonly CompanySize Size = CompanySize.Large;
        public static readonly DateTime CreatedAt = DateTime.Now;
        public static readonly DateTime UpdatedAt = DateTime.Now;
    }
}