using Boc.ExamOnline.Exams.Enums;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.ChoiceQuestions
{
    /// <summary>
    /// 选择题
    /// </summary>
    public class ChoiceQuestionDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        /// <summary>
        /// 试题类型,单选，多选
        /// </summary>
        public ChoiceQuestionCategory Category { get; set; }
        /// <summary>
        /// 试题标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 试题选项
        /// </summary>
        public List<ChoiceQuestionOptionDto> Options { get; set; }
        /// <summary>
        /// 问题注解
        /// </summary>
        public string Comment { get; set; }
        public Guid? TenantId { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public ChoiceQuestionOptionIndex Answer { get; set; }

    }
}
