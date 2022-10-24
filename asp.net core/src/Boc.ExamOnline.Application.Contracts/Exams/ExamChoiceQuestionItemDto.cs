using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Boc.ExamOnline.Exams
{
    /// <summary>
    /// 选择题条目
    /// </summary>
    public class ExamChoiceQuestionItemDto : EntityDto
    {
        public Guid ExamId { get; set; }
        public Guid ChoiceQuestionId { get; set; }
        public decimal Score { get; set; }
        public int Index { get; set; }
    }
}
