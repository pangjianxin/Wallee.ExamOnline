using Volo.Abp.Domain.Services;

namespace Boc.ExamOnline.Exams
{
    public class ExamManager : DomainService
    {
        public ExamManager(IExamRepository repository)
        {
            Repository = repository;
        }

        public IExamRepository Repository { get; }
    }
}
