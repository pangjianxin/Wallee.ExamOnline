using Boc.ExamOnline.Exams.Enums;
using System;

namespace Boc.ExamOnline.ChoiceQuestions
{
    public class CreateChoiceQuestionOptionDto
    {
        /// <summary>
        /// 选项内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 选项序号
        /// </summary>
        public ChoiceQuestionOptionIndex Index { get; set; }
        public bool IsAnswer { get; set; }
    }
}
