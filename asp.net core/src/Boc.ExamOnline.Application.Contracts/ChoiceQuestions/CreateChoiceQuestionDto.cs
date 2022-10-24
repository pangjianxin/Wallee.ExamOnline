using Boc.ExamOnline.Exams.Enums;
using System.Collections.Generic;

namespace Boc.ExamOnline.ChoiceQuestions
{
    public class CreateChoiceQuestionDto
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
        /// 问题注解
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 试题选项
        /// </summary>
        public List<CreateChoiceQuestionOptionDto> Options { get; set; }

    }
}
