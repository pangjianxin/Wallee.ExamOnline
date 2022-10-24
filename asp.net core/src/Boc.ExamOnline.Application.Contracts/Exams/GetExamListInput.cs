using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using AutoFilterer.Types;
using Volo.Abp.Application.Dtos;

namespace Boc.ExamOnline.Exams
{
    public class GetExamListInput : FilterBase, IPagedAndSortedResultRequest
    {
        [CompareTo(
         nameof(ExamDto.Title))]
        [StringFilterOptions(StringFilterOption.Contains)]
        public string Filter { get; set; }
        public int SkipCount { get; set; } = 0;
        public int MaxResultCount { get; set; } = 100;
        public string Sorting { get; set; }
    }
}
