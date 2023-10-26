using Common.AutomationIds;
using Microsoft.Playwright;

namespace SpecFlowTestProject.Pages
{
    public class InventoryPage
    {
        private readonly IPage _page;
        private string varProductName = "";

        public InventoryPage(IPage page) => _page = page;

        private ILocator BurgerMenu => _page.Locator(InventoryAutomationIds.BurgerMenuButtonView);
        private ILocator LogoutButton => _page.Locator(InventoryAutomationIds.LogoutButtonView);
        public ILocator VarProductItemButton => _page.GetByText(varProductName)
            .Locator("xpath=../../..").Locator("button");
        private ILocator CheckoutButton => _page.Locator("#shopping_cart_container a");
        
        /// <summary>
        /// Click burger menu button
        /// </summary>
        /// <returns></returns>
        public async Task ClickBurgerMenu() => await BurgerMenu.ClickAsync();

        /// <summary>
        /// Click logout button
        /// </summary>
        /// <returns></returns>
        public async Task ClickLogout() => await LogoutButton.ClickAsync();

        /// <summary>
        /// Click Add to product using product name e.g. "Sauce Labs Backpack"
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public async Task ClickAddToProduct(string productName)
        {
            varProductName = productName;
            await VarProductItemButton.ClickAsync();
        }

        /// <summary>
        /// Click checkout/cart button
        /// </summary>
        /// <returns></returns>
        public async Task ClickCheckoutButton() => await CheckoutButton.ClickAsync();
    }
}
