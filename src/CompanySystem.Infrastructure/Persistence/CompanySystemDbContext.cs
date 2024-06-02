using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Domain.Models;
using CompanySystem.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CompanySystem.Infrastructure.Persistence
{
    public class CompanySystemDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

        public DbSet<Company> Companies { get; set; }

        public CompanySystemDbContext(
            DbContextOptions<CompanySystemDbContext> options,
            IConfiguration configuration,
            PublishDomainEventsInterceptor publishDomainEventsInterceptor)
            : base(options)
        {
            _configuration = configuration;
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(CompanySystemDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        }
    }
}