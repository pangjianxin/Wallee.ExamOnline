using System;
using Volo.Abp.Application.Services;

namespace Boc.ExamOnline.Exams
{
    public interface IExamAppService : ICrudAppService<ExamDto, Guid, GetExamListInput, CreateExamDto, UpdateExamDto>
    {
    }
}
