using Microsoft.AspNetCore.Mvc.Testing;

namespace O_API_S_UI_Test;

[TestClass]
public sealed class Test1
{
    static WebApplicationFactory<Program> factory;
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        factory = new WebApplicationFactory<Program>();
    }

    [TestMethod]
    public async Task TestMethod1()
    {
        using var client = factory.CreateClient();
        var response = await client.GetAsync("/weatherforecast");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.IsTrue(content.Contains("Freezing"));
    }
}
