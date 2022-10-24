using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Boc.ExamOnline.ChoiceQuestions
{
    public class GetChoiceQuestionListInput : FilterBase, IPagedAndSortedResultRequest
    {
        [CompareTo(
           nameof(ChoiceQuestionDto.Title))]
        [StringFilterOptions(StringFilterOption.Contains)]
        public string Filter { get; set; }
        public int SkipCount { get; set; } = 0;
        public int MaxResultCount { get; set; } = 100;
        public string Sorting { get; set; }
    }
}
