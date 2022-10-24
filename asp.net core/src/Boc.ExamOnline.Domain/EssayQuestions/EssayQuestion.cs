using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.EssayQuestions
{
    /// <summary>
    /// 论述题
    /// </summary>
    public class EssayQuestion : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        private EssayQuestion()
        {

        }
        public EssayQuestion(Guid id, string title, string comment, Guid? tenantId)
        {
            Id = id;
            Title = title;
            Comment = comment;
            TenantId = tenantId;
        }

        public string Title { get; private set; }
        public string Comment { get; private set; }
        public Guid? TenantId { get; private set; }
    }
}
