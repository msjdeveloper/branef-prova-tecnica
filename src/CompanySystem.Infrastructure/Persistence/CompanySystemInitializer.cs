using System.Runtime.CompilerServices;

namespace CompanySystem.Infrastructure.Persistence
{
    public static class CompanySystemInitializer
    {
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
        [ModuleInitializer]
#pragma warning restore CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
        public static void Initialize()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
