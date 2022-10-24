using Boc.ExamOnline.ChoiceQuestions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boc.ExamOnline.EntityFrameworkCore
{
    public static class ExamOnlineDbContextIncludeExtensions
    {
        public static IQueryable<ChoiceQuestion> IncludeDetails(this IQueryable<ChoiceQuestion> query, bool includeDetails = true)
        {
            if (includeDetails)
            {
                return query.Include(it => it.Options);
            }
            return query;
        }

        public static IQueryable<Exams.Exam> IncludeDetails(this IQueryable<Exams.Exam> query, bool includeDetails = true)
        {
            if (includeDetails)
            {
                return query.Include(it => it.ChoiceQuestions)
                    .Include(it => it.EssayQuestions).Include(it => it.TrueOrFalseQuestions);
            }
            return query;
        }
    }
}
