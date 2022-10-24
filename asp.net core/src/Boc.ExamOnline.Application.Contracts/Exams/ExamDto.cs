using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.Exams
{
    /// <summary>
    /// 考试
    /// </summary>
    public class ExamDto : AuditedEntityDto<Guid>, IMultiTenant
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiredAt { get; set; }
        public decimal TotalScore { get; set; }
        public ICollection<ExamChoiceQuestionItemDto> ChoiceQuestions { get; set; }
        public ICollection<ExamTrueOrFalseQuestionItemDto> TrueOrFalseQuestions { get; set; }
        public ICollection<ExamEssayQuestionItemDto> EssayQuestions { get; set; }
        public Guid? TenantId { get; set; }
    }
}
