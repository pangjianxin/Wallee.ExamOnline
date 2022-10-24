using Boc.ExamOnline.Exams.Enums;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.TrueOrFalseQuestions
{
    /// <summary>
    /// 判断题
    /// </summary>
    public class TrueOrFalseQuestionDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public string Title { get; set; }

        public TrueOrFalseQuestionAnswer Answer { get; set; }

        public Guid? TenantId { get; set; }
    }
}
