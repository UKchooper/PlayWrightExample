using Common;
using Microsoft.Playwright;


namespace PlayWrightDemo.Pages
{
    public class LoginPageUpgraded
    {
        private IPage _page;

        public LoginPageUpgraded(IPage page) => _page = page;

        private ILocator LnkLogin => _page.Locator(AutomationIds.LnkLoginView);
        private ILocator TextUserName => _page.Locator(AutomationIds.TextUserNameView);
        private ILocator TextPassword => _page.Locator(AutomationIds.TextPasswordView);
        private ILocator BtnLogin => _page.Locator(AutomationIds.BtnLoginView);
        private ILocator LnkEmployeeDetails => _page.Locator(AutomationIds.LnkEmployeeDetailsView);
        private ILocator LnkEmployeeLists => _page.Locator(AutomationIds.LnkEmployeeDetailsView);

        public async Task ClickLogin()
        {
            await LnkLogin.ClickAsync();
            await _page.WaitForURLAsync("**/Login");
        }

        public async Task Login(string userName, string password)
        {
            await TextUserName.FillAsync(userName);
            await TextPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
        }

        public async Task ClickEmployeeList() => await LnkEmployeeLists.ClickAsync();

        public async Task<bool> IsEmployeeDetailsExists() => await LnkEmployeeDetails.IsVisibleAsync();
    }
}
