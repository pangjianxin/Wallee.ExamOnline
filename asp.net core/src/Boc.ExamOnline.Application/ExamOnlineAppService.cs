using System;
using System.Collections.Generic;
using System.Text;
using Boc.ExamOnline.Localization;
using Volo.Abp.Application.Services;

namespace Boc.ExamOnline;

/* Inherit your application services from this class.
 */
public abstract class ExamOnlineAppService : ApplicationService
{
    protected ExamOnlineAppService()
    {
        LocalizationResource = typeof(ExamOnlineResource);
    }
}
