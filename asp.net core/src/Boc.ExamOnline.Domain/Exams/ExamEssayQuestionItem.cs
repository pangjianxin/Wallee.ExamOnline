using System;
using Volo.Abp.Domain.Entities;

namespace Boc.ExamOnline.Exams
{
    /// <summary>
    /// 论述题条目
    /// </summary>
    public class ExamEssayQuestionItem : Entity
    {
        private ExamEssayQuestionItem()
        {

        }
        public ExamEssayQuestionItem(
            Guid examId,
            Guid essayQuestionId, decimal score, int index)
        {
            ExamId = examId;
            EssayQuestionId = essayQuestionId;
            Score = score;
            Index = index;
        }

        public Guid ExamId { get; private set; }
        public Guid EssayQuestionId { get; private set; }
        public decimal Score { get; private set; }
        public int Index { get; private set; }

        public override object[] GetKeys()
        {
            return new object[] { ExamId, EssayQuestionId };
        }
    }
}
