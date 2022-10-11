using Boc.ExamOnline.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Boc.ExamOnline.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ExamOnlinePageModel : AbpPageModel
{
    protected ExamOnlinePageModel()
    {
        LocalizationResourceType = typeof(ExamOnlineResource);
    }
}
