using Microsoft.Playwright;

namespace PlayWrightDemo.Pages
{
    public class LoginPage
    {
        private IPage _page;
        private readonly ILocator _lnkLogin;
        private readonly ILocator _textUserName;
        private readonly ILocator _textPassword;
        private readonly ILocator _btnLogin;
        private readonly ILocator _lnkEmployeeDetails;

        public LoginPage(IPage page)
        {
            _page = page;
            _lnkLogin = _page.Locator("text=Login");
            _textUserName = _page.Locator("#UserName");
            _textPassword = _page.Locator("#Password");
            _btnLogin = _page.Locator("text=Log in");
            _lnkEmployeeDetails = _page.Locator("text='Employee Details'");
        }

        public async Task ClickLogin() => await _lnkLogin.ClickAsync();

        public async Task Login(string userName, string password)
        {
            await _textUserName.FillAsync(userName);
            await _textPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await _lnkEmployeeDetails.IsVisibleAsync();
    }
}
