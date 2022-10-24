using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Boc.ExamOnline.Exams
{
    /// <summary>
    /// 考试
    /// </summary>
    public class Exam : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        private Exam()
        {

        }
        public Exam(Guid id, string title,
            string description, DateTime expiredAt,
            decimal totalScore = 100M, Guid? tenantId = null)
        {
            Id = id;
            Title = title;
            Description = description;
            TenantId = tenantId;
            ChoiceQuestions = new List<ExamChoiceQuestionItem>();
            TrueOrFalseQuestions = new List<ExamTrueOrFalseQuestionItem>();
            EssayQuestions = new List<ExamEssayQuestionItem>();
            ExpiredAt = expiredAt;
            TotalScore = totalScore;
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ExpiredAt { get; private set; }
        public decimal TotalScore { get; private set; }
        public ICollection<ExamChoiceQuestionItem> ChoiceQuestions { get; private set; }
        public ICollection<ExamTrueOrFalseQuestionItem> TrueOrFalseQuestions { get; private set; }
        public ICollection<ExamEssayQuestionItem> EssayQuestions { get; private set; }
        public Guid? TenantId { get; private set; }
    }
}
