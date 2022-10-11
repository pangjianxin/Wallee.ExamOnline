using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Boc.ExamOnline.Data;

/* This is used if database provider does't define
 * IExamOnlineDbSchemaMigrator implementation.
 */
public class NullExamOnlineDbSchemaMigrator : IExamOnlineDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
