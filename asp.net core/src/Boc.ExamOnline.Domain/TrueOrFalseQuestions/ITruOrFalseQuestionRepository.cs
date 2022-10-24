using System;
using Volo.Abp.Domain.Repositories;

namespace Boc.ExamOnline.TrueOrFalseQuestions
{
    public interface ITruOrFalseQuestionRepository : IRepository<TrueOrFalseQuestion, Guid>
    {
    }
}
