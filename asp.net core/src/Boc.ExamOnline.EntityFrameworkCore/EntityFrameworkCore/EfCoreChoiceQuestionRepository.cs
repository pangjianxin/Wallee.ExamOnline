using Boc.ExamOnline.ChoiceQuestions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Boc.ExamOnline.EntityFrameworkCore
{
    public class EfCoreChoiceQuestionRepository : EfCoreRepository<ExamOnlineDbContext, ChoiceQuestion, Guid>,
        IChoiceQuestionRepository
    {
        public EfCoreChoiceQuestionRepository(IDbContextProvider<ExamOnlineDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        public override Task<List<ChoiceQuestion>> GetListAsync(Expression<Func<ChoiceQuestion, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return base.GetListAsync(predicate, includeDetails, cancellationToken);
        }

        public override async Task<IQueryable<ChoiceQuestion>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}
