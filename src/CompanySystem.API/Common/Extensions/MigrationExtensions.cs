using CompanySystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompanySystem.API.Common.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using CompanySystemDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<CompanySystemDbContext>();

        dbContext.Database.Migrate();
    }
}
