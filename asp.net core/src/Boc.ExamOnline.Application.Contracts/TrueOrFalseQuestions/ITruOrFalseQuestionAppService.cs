using System;
using Volo.Abp.Application.Services;

namespace Boc.ExamOnline.TrueOrFalseQuestions
{
    public interface ITruOrFalseQuestionAppService :
        ICrudAppService<TrueOrFalseQuestionDto, Guid, GetTrueOrFalseQuestionListInput, CreateTrueOrFalseQuestionDto, UpdateTrueOrFalseQuestionDto>
    {
    }
}
