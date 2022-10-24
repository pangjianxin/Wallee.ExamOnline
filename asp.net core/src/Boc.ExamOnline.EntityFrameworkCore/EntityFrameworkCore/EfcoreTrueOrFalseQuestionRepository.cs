using Boc.ExamOnline.TrueOrFalseQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Boc.ExamOnline.EntityFrameworkCore
{
    public class EfcoreTrueOrFalseQuestionRepository : EfCoreRepository<ExamOnlineDbContext, TrueOrFalseQuestion, Guid>,
        ITruOrFalseQuestionRepository
    {
        public EfcoreTrueOrFalseQuestionRepository(IDbContextProvider<ExamOnlineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
