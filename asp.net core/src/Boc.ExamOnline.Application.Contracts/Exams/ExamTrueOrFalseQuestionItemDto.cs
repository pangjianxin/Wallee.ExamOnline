using System;
using Volo.Abp.Application.Dtos;

namespace Boc.ExamOnline.Exams
{
    public class ExamTrueOrFalseQuestionItemDto : EntityDto
    {
        public Guid ExamId { get; set; }
        public Guid TrueOrFalseQuestionId { get; set; }
        public decimal Score { get; set; }
        public int Index { get; set; }
    }
}
