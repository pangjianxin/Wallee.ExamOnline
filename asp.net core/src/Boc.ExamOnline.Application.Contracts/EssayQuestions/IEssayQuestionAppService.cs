using System;
using Volo.Abp.Application.Services;

namespace Boc.ExamOnline.EssayQuestions
{
    public interface IEssayQuestionAppService : ICrudAppService<EssayQuestionDto, Guid, GetEssayQuestionListInput, CreateEssayQuestionDto, UpdateEssayQuestionDto>
    {
    }
}
