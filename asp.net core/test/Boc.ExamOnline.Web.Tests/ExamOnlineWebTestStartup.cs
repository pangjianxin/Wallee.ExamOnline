using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace Boc.ExamOnline;

public class ExamOnlineWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<ExamOnlineWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
