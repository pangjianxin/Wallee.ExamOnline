using Volo.Abp.Domain.Services;

namespace Boc.ExamOnline.TrueOrFalseQuestions
{
    public class TrueOrFalseQuestionManager : DomainService
    {
        public TrueOrFalseQuestionManager(ITruOrFalseQuestionRepository repository)
        {
            Repository = repository;
        }

        public ITruOrFalseQuestionRepository Repository { get; }
    }
}
