using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Boc.ExamOnline.Pages;

public class Index_Tests : ExamOnlineWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
