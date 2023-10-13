﻿using Microsoft.Playwright;

namespace PlayWrightDemo.Pages
{
    public class LoginPageUpgraded
    {
        private IPage _page;

        public LoginPageUpgraded(IPage page) => _page = page;

        private ILocator LnkLogin => _page.Locator("text=Login");
        private ILocator TextUserName => _page.Locator("#UserName");
        private ILocator TextPassword => _page.Locator("#Password");
        private ILocator BtnLogin => _page.Locator("text=Log in");
        private ILocator LnkEmployeeDetails => _page.Locator("text='Employee Details'");        

        public async Task ClickLogin() => await LnkLogin.ClickAsync();

        public async Task Login(string userName, string password)
        {
            await TextUserName.FillAsync(userName);
            await TextPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExists() => await LnkEmployeeDetails.IsVisibleAsync();
    }
}