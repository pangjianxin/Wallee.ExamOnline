using System;
using Volo.Abp.Domain.Entities;

namespace Boc.ExamOnline.Exams
{
    public class ExamTrueOrFalseQuestionItem : Entity
    {
        private ExamTrueOrFalseQuestionItem()
        {

        }
        public ExamTrueOrFalseQuestionItem(
            Guid examId, Guid trueOrFalseQuestionId,
            decimal score, int index)
        {
            ExamId = examId;
            TrueOrFalseQuestionId = trueOrFalseQuestionId;
            Score = score;
            Index = index;
        }

        public Guid ExamId { get; private set; }
        public Guid TrueOrFalseQuestionId { get; private set; }
        public decimal Score { get; private set; }
        public int Index { get; private set; }

        public override object[] GetKeys()
        {
            return new object[]
            {
                ExamId,TrueOrFalseQuestionId
            };
        }
    }
}
