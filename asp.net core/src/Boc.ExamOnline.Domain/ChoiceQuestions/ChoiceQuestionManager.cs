using Boc.ExamOnline.Exams.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Boc.ExamOnline.ChoiceQuestions
{
    public class ChoiceQuestionManager : DomainService
    {
        public ChoiceQuestionManager(IChoiceQuestionRepository repository)
        {
            Repository = repository;
        }
        public IChoiceQuestionRepository Repository { get; }

        public async Task<ChoiceQuestion> CreateAsync(string title,
            ChoiceQuestionCategory category,
            List<(string content, ChoiceQuestionOptionIndex index, bool isAnswer)> options,
            string comment = null)
        {
            if (await Repository.AnyAsync(it => it.Title == title && it.Category == category))
            {
                throw new UserFriendlyException("已存在相同标题的选择题");
            }
            var question = new ChoiceQuestion(GuidGenerator.Create(), category, title, comment, CurrentTenant.Id);
            var questionOptions = new List<ChoiceQuestionOption>();

            foreach (var (content, index, isAnswer) in options)
            {
                questionOptions.Add(new ChoiceQuestionOption(question.Id, content, index, isAnswer));
            }

            question.SetupOptions(questionOptions);

            return question;
        }
    }
}
