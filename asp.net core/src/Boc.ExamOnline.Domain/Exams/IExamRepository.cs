using System;
using Volo.Abp.Domain.Repositories;

namespace Boc.ExamOnline.Exams
{
    public interface IExamRepository : IRepository<Exam, Guid>
    {
    }
}
