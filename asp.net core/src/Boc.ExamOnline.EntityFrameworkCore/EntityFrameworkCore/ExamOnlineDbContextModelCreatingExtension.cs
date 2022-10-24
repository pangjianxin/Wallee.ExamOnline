using Boc.ExamOnline.ChoiceQuestions;
using Boc.ExamOnline.EssayQuestions;
using Boc.ExamOnline.Exams;
using Boc.ExamOnline.Exams.Consts;
using Boc.ExamOnline.TrueOrFalseQuestions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Boc.ExamOnline.EntityFrameworkCore
{
    public static class ExamOnlineDbContextModelCreatingExtension
    {
        public static void ConfigExamOnline(this ModelBuilder builder)
        {
            builder.Entity<ChoiceQuestion>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "ChoiceQuestions", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();
                it.Ignore(it => it.Answer);
                it.Property(it => it.Title).IsRequired().HasMaxLength(ChoiceQuestionConsts.MaxTitleLength);
                it.Property(it => it.Comment).IsRequired(false).HasMaxLength(ChoiceQuestionConsts.MaxCommentLenth);

                it.HasMany(it => it.Options).WithOne().HasForeignKey(it => it.QuestionId);
            });

            builder.Entity<ChoiceQuestionOption>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "ChoiceQuestionOptions", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();

                it.HasKey(it => new { it.QuestionId, it.Index });

                it.Property(it => it.Content).IsRequired().HasMaxLength(ChoiceQuestionConsts.MaxOptionContentLength);

                it.HasOne<ChoiceQuestion>().WithMany(it => it.Options).HasForeignKey(it => it.QuestionId);
            });

            builder.Entity<EssayQuestion>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "EssayQuestions", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();

                it.Property(it => it.Title).IsRequired().HasMaxLength(EssayQuestionConsts.MaxTitleLength);
                it.Property(it => it.Comment).IsRequired(false).HasMaxLength(EssayQuestionConsts.MaxCommentLegnth);
            });

            builder.Entity<TrueOrFalseQuestion>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "TrueOrFalseQuestions", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();

                it.Property(it => it.Title).IsRequired().HasMaxLength(TrueOrFalseQuestionConsts.MaxTitleLength);
            });

            builder.Entity<Exam>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "Exams", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();

                it.Property(it => it.Title).IsRequired().HasMaxLength(ExamConsts.MaxTitleLength);
                it.Property(it => it.Description).IsRequired().HasMaxLength(ExamConsts.MaxDescriptionLength);
                it.Property(it => it.TotalScore).HasColumnType("decimal(18,2)");
                it.HasMany(it => it.ChoiceQuestions).WithOne().HasForeignKey(it => it.ExamId);
            });

            builder.Entity<ExamChoiceQuestionItem>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "ExamChoiceQuestionItems", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();
                it.HasKey(it => new { it.ExamId, it.ChoiceQuestionId });
                it.Property(it => it.Score).HasColumnType("decimal(18,2)");
                it.HasOne<Exam>().WithMany(it => it.ChoiceQuestions).HasForeignKey(it => it.ExamId);

                it.HasOne<ChoiceQuestion>().WithMany().HasForeignKey(it => it.ChoiceQuestionId);
            });

            builder.Entity<ExamEssayQuestionItem>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "ExamEssayQuestionItems", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();
                it.HasKey(it => new { it.ExamId, it.EssayQuestionId });
                it.Property(it => it.Score).HasColumnType("decimal(18,2)");

                it.HasOne<Exam>().WithMany(it => it.EssayQuestions).HasForeignKey(it => it.ExamId);
                it.HasOne<ChoiceQuestion>().WithMany().HasForeignKey(it => it.EssayQuestionId);
            });

            builder.Entity<ExamTrueOrFalseQuestionItem>(it =>
            {
                it.ToTable(ExamOnlineConsts.DbTablePrefix + "ExamTrueOrFalseQuestionItems", ExamOnlineConsts.DbSchema);
                it.ConfigureByConvention();
                it.HasKey(it => new { it.ExamId, it.TrueOrFalseQuestionId });
                it.Property(it => it.Score).HasColumnType("decimal(18,2)");

                it.HasOne<Exam>().WithMany(it => it.TrueOrFalseQuestions).HasForeignKey(it => it.ExamId);
                it.HasOne<ChoiceQuestion>().WithMany().HasForeignKey(it => it.TrueOrFalseQuestionId);
            });
        }
    }
}
