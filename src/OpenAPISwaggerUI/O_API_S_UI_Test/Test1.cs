using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Playwright;

namespace O_API_S_UI_Test;

[TestClass]
public sealed class Test1
{
    static CustomWebApplicationFactory factory;
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        factory = new ();
        var exitCode = Microsoft.Playwright.Program.Main(new[] { "install" });
        if (exitCode != 0)
        {
            throw new Exception($"Playwright exited with code {exitCode}");
        }
        var url = factory.ServerAddress;
        Console.WriteLine($"Server address: {url}");
    }

    [TestMethod]
    public async Task TestWeHaveRealWebServer()
    {
        
        using var client = factory.CreateDefaultClient();
        var response = await client.GetAsync("/weatherforecast");
        response.EnsureSuccessStatusCode();
        var baseAddress = factory.ServerAddress;
        if(!baseAddress.EndsWith("/"))
        {
            baseAddress += "/";    
        }
        using var playwright = await Playwright.CreateAsync();
        var request = await playwright.APIRequest.NewContextAsync();
            
        var response1 = await request.GetAsync(baseAddress+"weatherforecast");
        Assert.IsTrue(response1.Ok);


    }
    [TestMethod]
    public async Task TestIntegrationWorks()
    {

        var baseAddress = factory.ServerAddress;
        if (!baseAddress.EndsWith("/"))
        {
            baseAddress += "/";
        }
        using var playwright = await Playwright.CreateAsync();
        var request = await playwright.APIRequest.NewContextAsync();

        await using var browser = await playwright.Chromium.LaunchAsync();
        var context = await browser.NewContextAsync(new()
        {
            //RecordVideoDir = curDirVideos
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(baseAddress + "swagger");
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "swagger.png" });


    }

}
