using Boc.ExamOnline.Exams.Enums;
using System;
using Volo.Abp.Domain.Entities;

namespace Boc.ExamOnline.ChoiceQuestions
{
    /// <summary>
    /// 选择题的选项
    /// </summary>
    public class ChoiceQuestionOption : Entity
    {
        private ChoiceQuestionOption()
        {

        }
        public ChoiceQuestionOption(
            Guid questionId,
            string content,
            ChoiceQuestionOptionIndex index,
            bool isAnswer)
        {
            QuestionId = questionId;
            Content = content;
            Index = index;
            IsAnswer = isAnswer;
        }
        /// <summary>
        /// 试题id
        /// </summary>
        public Guid QuestionId { get; private set; }
        /// <summary>
        /// 选项内容
        /// </summary>
        public string Content { get; private set; }
        /// <summary>
        /// 选项序号
        /// </summary>
        public ChoiceQuestionOptionIndex Index { get; private set; }
        /// <summary>
        /// 正确答案标记
        /// </summary>
        public bool IsAnswer { get; private set; }

        public override object[] GetKeys()
        {
            return new object[] { QuestionId, Index };
        }
    }
}
