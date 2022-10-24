using Boc.ExamOnline.EssayQuestions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Boc.ExamOnline.EntityFrameworkCore
{
    public class EfCoreEssayQuestionRepository : EfCoreRepository<ExamOnlineDbContext, EssayQuestion, Guid>, IEssayQuestionRepository
    {
        public EfCoreEssayQuestionRepository(IDbContextProvider<ExamOnlineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

    }
}
