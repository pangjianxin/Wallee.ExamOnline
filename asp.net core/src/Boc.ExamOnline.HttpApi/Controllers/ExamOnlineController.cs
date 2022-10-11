using Boc.ExamOnline.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Boc.ExamOnline.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ExamOnlineController : AbpControllerBase
{
    protected ExamOnlineController()
    {
        LocalizationResource = typeof(ExamOnlineResource);
    }
}
