using AutoFilterer.Extensions;
using Boc.ExamOnline.Exams.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Boc.ExamOnline.ChoiceQuestions
{
    public class ChoiceQuestionAppService :
        CrudAppService<ChoiceQuestion, ChoiceQuestionDto, Guid, GetChoiceQuestionListInput, CreateChoiceQuestionDto, UpdateChoiceQuestionDto>,
        IChoiceQuestionAppService
    {
        public ChoiceQuestionAppService(
            IChoiceQuestionRepository choiceQuestionRepository,
            ChoiceQuestionManager choiceQuestionManager) : base(choiceQuestionRepository)
        {
            ChoiceQuestionRepository = choiceQuestionRepository;
            ChoiceQuestionManager = choiceQuestionManager;
        }

        public override async Task<ChoiceQuestionDto> CreateAsync(CreateChoiceQuestionDto input)
        {
            List<(string content, ChoiceQuestionOptionIndex index, bool isAnswer)> options = new();
            foreach (var option in input.Options)
            {
                options.Add((option.Content, option.Index, option.IsAnswer));
            }
            var question = await ChoiceQuestionManager.CreateAsync(input.Title, input.Category, options, input.Comment);

            await Repository.InsertAsync(question);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<ChoiceQuestion, ChoiceQuestionDto>(question);
        }

        public IChoiceQuestionRepository ChoiceQuestionRepository { get; }
        public ChoiceQuestionManager ChoiceQuestionManager { get; }

        protected override async Task<IQueryable<ChoiceQuestion>> CreateFilteredQueryAsync(GetChoiceQuestionListInput input)
        {
            var filter = (await Repository.WithDetailsAsync()).ApplyFilter(input);
            return filter;
        }

    }
}
