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
}