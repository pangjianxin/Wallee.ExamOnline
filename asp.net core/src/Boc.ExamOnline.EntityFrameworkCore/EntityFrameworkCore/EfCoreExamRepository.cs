using Boc.ExamOnline.Exams;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Boc.ExamOnline.EntityFrameworkCore
{
    public class EfCoreExamRepository : EfCoreRepository<ExamOnlineDbContext, Exams.Exam, Guid>, IExamRepository
    {
        public EfCoreExamRepository(IDbContextProvider<ExamOnlineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public override async Task<IQueryable<Exam>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}
