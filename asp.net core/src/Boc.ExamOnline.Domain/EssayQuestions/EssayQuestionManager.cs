using Volo.Abp.Domain.Services;

namespace Boc.ExamOnline.EssayQuestions
{
    public class EssayQuestionManager : DomainService
    {
        public EssayQuestionManager(IEssayQuestionRepository repository)
        {
            Repository = repository;
        }

        public IEssayQuestionRepository Repository { get; }
    }
}
