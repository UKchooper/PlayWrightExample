using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlayWrightDemo.Pages;

namespace PlayWrightDemo;

public class NUnitPlayWright : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Test]
    public async Task Test1()
    {
        var lnkLogin = Page.Locator("text=Login");

        await lnkLogin.ClickAsync();

        await Page.ClickAsync("text=Login");
        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");

        var btnLogin = Page.Locator("input", new PageLocatorOptions { HasTextString = "Log in" });
        await btnLogin.ClickAsync();

        //await Page.ClickAsync("text=Log in");

        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TestWithPOM()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");

        var loginPage = new LoginPageUpgraded(Page);

        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");
        var isExist = await loginPage.IsEmployeeDetailsExists();

        Assert.IsTrue(isExist);
    }

    [Test]
    public async Task TestNetwork()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com");

        LoginPageUpgraded loginPage = new LoginPageUpgraded(Page);

        await loginPage.ClickLogin();

        // Same as below code
        //var waitResponse = Page.WaitForResponseAsync("**/Employee");
        //await loginPage.ClickEmployeeList();
        //var getResponse = await waitResponse;

        var repsonse = await Page.RunAndWaitForResponseAsync(async () =>
        {
            await loginPage.ClickEmployeeList();
        }, x => x.Url.Contains("/Employee") && x.Status == 200);
    }
}