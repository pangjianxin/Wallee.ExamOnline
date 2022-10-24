using Boc.ExamOnline.Exams.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace Boc.ExamOnline.ChoiceQuestions
{
    public class ChoiceQuestionOptionDto : EntityDto
    {
        /// <summary>
        /// 试题id
        /// </summary>
        public Guid QuestionId { get; set; }
        /// <summary>
        /// 选项内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 选项序号
        /// </summary>
        public ChoiceQuestionOptionIndex Index { get; set; }
    }
}
