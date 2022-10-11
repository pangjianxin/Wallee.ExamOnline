using Boc.ExamOnline.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Boc.ExamOnline;

[DependsOn(
    typeof(ExamOnlineEntityFrameworkCoreTestModule)
    )]
public class ExamOnlineDomainTestModule : AbpModule
{

}
