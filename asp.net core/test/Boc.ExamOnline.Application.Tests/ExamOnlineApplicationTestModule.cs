using Volo.Abp.Modularity;

namespace Boc.ExamOnline;

[DependsOn(
    typeof(ExamOnlineApplicationModule),
    typeof(ExamOnlineDomainTestModule)
    )]
public class ExamOnlineApplicationTestModule : AbpModule
{

}
