using Boc.ExamOnline.Exams.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.TrueOrFalseQuestions
{
    /// <summary>
    /// 判断题
    /// </summary>
    public class TrueOrFalseQuestion : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        private TrueOrFalseQuestion()
        {

        }
        public TrueOrFalseQuestion(Guid id, string title, TrueOrFalseQuestionAnswer answer, Guid? tenantId)
        {
            Id = id;
            Title = title;
            Answer = answer;
            TenantId = tenantId;
        }

        public string Title { get; private set; }

        public TrueOrFalseQuestionAnswer Answer { get; private set; }

        public Guid? TenantId { get; private set; }
    }
}
