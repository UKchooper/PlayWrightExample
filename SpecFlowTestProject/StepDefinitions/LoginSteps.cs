using FluentAssertions;
using Microsoft.Playwright.NUnit;
using PlayWrightDemo.Pages;
using SpecFlowTestProject.Drivers;
using SpecFlowTestProject.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowTestProject.StepDefinitions
{
    [Binding]
    public sealed class LoginSteps : PageTest
    {
        private readonly Driver _driver;
        private readonly LoginPage _loginPage;
        private readonly InventoryPage _inventoryPage;

        public LoginSteps(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
            _inventoryPage = new InventoryPage(_driver.Page);
        }

        [Given(@"I navigate to website")]
        public void GivenINavigateToWebsite()
        {
            _driver.Page.GotoAsync("https://www.saucedemo.com/");
        }

        [When(@"I enter the login details '([^']*)' and '([^']*)'")]
        [Given(@"I enter the login details '([^']*)' and '([^']*)'")]
        public async Task WhenIEnterTheLoginDetailsAnd(string username, string password)
        {
            await _loginPage.ClickAndEnterUsernameDetails(username);
            await _loginPage.ClickAndEnterPasswordDetails(password);
            await _loginPage.ClickLoginButton();
        }

        [Then(@"I valiate the login error '([^']*)'")]
        public async Task ThenIValiateTheLoginError(string errorMessage)
        {
            errorMessage.Should().Be(await _loginPage.TextLoginError.InnerTextAsync());
        }

        [Then(@"I validate the url '([^']*)'")]
        public async Task ThenIValidateTheUrl(string url)
        {
            await Expect(_driver.Page).ToHaveURLAsync(url);
        }

        [Then(@"I select user log out")]
        public async Task ThenISelectUserLogOut()
        {
            await _inventoryPage.ClickBurgerMenu();
            await _inventoryPage.ClickLogout();
        }
    }
}