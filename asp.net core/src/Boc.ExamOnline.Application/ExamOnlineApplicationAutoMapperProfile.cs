using AutoMapper;
using Boc.ExamOnline.ChoiceQuestions;

namespace Boc.ExamOnline;

public class ExamOnlineApplicationAutoMapperProfile : Profile
{
    public ExamOnlineApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<ChoiceQuestionOption, ChoiceQuestionOptionDto>();
        CreateMap<ChoiceQuestion, ChoiceQuestionDto>()
            .ForMember(it => it.Options, config => config.MapFrom(it => it.Options))
            .ForMember(it => it.Answer, config => config.MapFrom(it => it.Answer));
    }
}
