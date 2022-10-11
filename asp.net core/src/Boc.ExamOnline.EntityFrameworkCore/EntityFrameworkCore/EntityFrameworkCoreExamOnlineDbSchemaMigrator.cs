using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Boc.ExamOnline.Data;
using Volo.Abp.DependencyInjection;

namespace Boc.ExamOnline.EntityFrameworkCore;

public class EntityFrameworkCoreExamOnlineDbSchemaMigrator
    : IExamOnlineDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreExamOnlineDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ExamOnlineDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ExamOnlineDbContext>()
            .Database
            .MigrateAsync();
    }
}
