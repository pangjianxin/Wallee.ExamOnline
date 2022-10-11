using System.Threading.Tasks;

namespace Boc.ExamOnline.Data;

public interface IExamOnlineDbSchemaMigrator
{
    Task MigrateAsync();
}
