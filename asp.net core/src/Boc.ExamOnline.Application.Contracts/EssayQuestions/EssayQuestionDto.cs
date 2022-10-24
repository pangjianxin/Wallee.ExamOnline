using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.EssayQuestions
{
    /// <summary>
    /// 论述题
    /// </summary>
    public class EssayQuestionDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public Guid? TenantId { get; set; }
    }
}
