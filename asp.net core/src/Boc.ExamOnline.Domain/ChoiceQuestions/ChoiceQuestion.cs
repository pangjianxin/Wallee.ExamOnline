using Boc.ExamOnline.Exams.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.ChoiceQuestions
{
    /// <summary>
    /// 选择题
    /// </summary>
    public class ChoiceQuestion : AuditedAggregateRoot<Guid>, IMultiTenant
    {
        private ChoiceQuestion() { }
        public ChoiceQuestion(
            Guid id,
            ChoiceQuestionCategory category,
            string title,
            string comment,
            Guid? tenantId)
        {
            Id = id;
            Category = category;
            Title = title;
            Options = new List<ChoiceQuestionOption>();
            Comment = comment;
            TenantId = tenantId;
        }

        /// <summary>
        /// 试题类型,单选，多选
        /// </summary>
        public ChoiceQuestionCategory Category { get; set; }
        /// <summary>
        /// 试题标题
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// 试题选项
        /// </summary>
        public ICollection<ChoiceQuestionOption> Options { get; private set; }
        /// <summary>
        /// 问题注解
        /// </summary>
        public string Comment { get; private set; }
        public Guid? TenantId { get; private set; }
        /// <summary>
        /// 答案
        /// </summary>
        public ChoiceQuestionOptionIndex Answer
        {
            get
            {
                //if (Category == ChoiceQuestionCategory.单选题)
                //{
                //    return Options.FirstOrDefault(it => it.IsAnswer).Index;
                //}
                return Options.Where(it => it.IsAnswer)
                    .Select(it => it.Index)
                    .Aggregate((cur, next) => cur | next);
            }
        }

        public void SetupOptions(List<ChoiceQuestionOption> options)
        {
            Options = options;
        }
    }
}
