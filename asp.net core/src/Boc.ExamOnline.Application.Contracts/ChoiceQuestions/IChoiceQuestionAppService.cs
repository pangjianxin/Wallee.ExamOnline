using System;
using Volo.Abp.Application.Services;

namespace Boc.ExamOnline.ChoiceQuestions
{
    public interface IChoiceQuestionAppService : ICrudAppService<ChoiceQuestionDto, Guid, GetChoiceQuestionListInput, CreateChoiceQuestionDto, UpdateChoiceQuestionDto>
    {
    }
}
