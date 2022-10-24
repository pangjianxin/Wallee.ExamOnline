using System;
using Volo.Abp.Application.Dtos;

namespace Boc.ExamOnline.Exams
{
    /// <summary>
    /// 论述题条目
    /// </summary>
    public class ExamEssayQuestionItemDto : EntityDto
    {
        public Guid ExamId { get; set; }
        public Guid EssayQuestionId { get; set; }
        public decimal Score { get; set; }
        public int Index { get; set; }
    }
}
