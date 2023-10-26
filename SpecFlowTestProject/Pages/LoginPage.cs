using Common;
using Microsoft.Playwright;


namespace PlayWrightDemo.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page) => _page = page;

        private ILocator UsernameText => _page.Locator(LoginAutomationIds.TextUsernameView);
        private ILocator TextPassword => _page.Locator(LoginAutomationIds.TextPasswordView);
        private ILocator ButtonLogin => _page.Locator(LoginAutomationIds.ButtonLoginView);
        public ILocator TextLoginError => _page.Locator(LoginAutomationIds.TextLoginErrorView);

        /// <summary>
        /// Click and enter Username details
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task ClickAndEnterUsernameDetails(string username)
        {
            await UsernameText.ClickAsync();
            await UsernameText.FillAsync(username);
        }

        /// <summary>
        /// Click and enter Password details
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task ClickAndEnterPasswordDetails(string password) => await TextPassword.FillAsync(password);

        /// <summary>
        /// Click login button
        /// </summary>
        /// <returns></returns>
        public async Task ClickLoginButton() => await ButtonLogin.ClickAsync();

        /// <summary>
        /// Return Login text.. doesn't work!
        /// </summary>
        /// <returns></returns>
        public async Task ReturnLoginErrorText()
        {
            await TextLoginError.GetAttributeAsync("text");
        } 
    }
}
