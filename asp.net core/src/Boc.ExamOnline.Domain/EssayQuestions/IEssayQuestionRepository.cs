using System;
using Volo.Abp.Domain.Repositories;

namespace Boc.ExamOnline.EssayQuestions
{
    public interface IEssayQuestionRepository : IRepository<EssayQuestion, Guid>
    {
    }
}
