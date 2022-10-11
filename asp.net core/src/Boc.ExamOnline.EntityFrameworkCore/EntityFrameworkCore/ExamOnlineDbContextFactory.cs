using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Boc.ExamOnline.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ExamOnlineDbContextFactory : IDesignTimeDbContextFactory<ExamOnlineDbContext>
{
    public ExamOnlineDbContext CreateDbContext(string[] args)
    {
        ExamOnlineEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ExamOnlineDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ExamOnlineDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Boc.ExamOnline.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
