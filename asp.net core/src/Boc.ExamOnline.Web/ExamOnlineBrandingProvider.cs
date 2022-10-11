using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Boc.ExamOnline.Web;

[Dependency(ReplaceServices = true)]
public class ExamOnlineBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ExamOnline";
}
