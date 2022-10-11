using Boc.ExamOnline.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Boc.ExamOnline.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ExamOnlineEntityFrameworkCoreModule),
    typeof(ExamOnlineApplicationContractsModule)
    )]
public class ExamOnlineDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
