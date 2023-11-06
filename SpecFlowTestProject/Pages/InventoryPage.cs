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
        public ILocator VarProductItem => _page.GetByText(varProductName);
        public ILocator AddToCartProductPage => _page.GetByRole(AriaRole.Button, new() { Name = "Add to cart" });
        public ILocator VarProductPriceText => _page.GetByText(varProductName)
            .Locator("xpath=../..").Locator("xpath=//div[@class='inventory_item_price']");
        //public ILocator VarProductItemButton => _page.GetByText(varProductName)
        //    .Locator("xpath=../../..").GetByRole(AriaRole.Button, new() { Name = "Add to cart" });
        private ILocator CheckoutButton => _page.Locator("#shopping_cart_container a");
        private ILocator GetInventoryItems => _page.Locator("xpath=//div[@class='inventory_item']");
        public ILocator InventoryItemTitles => GetInventoryItems.Locator("xpath=//div[@class='inventory_item_name ']");
        public ILocator InventoryItemDescriptions => GetInventoryItems.Locator("xpath=//div[@class='inventory_item_desc']");
        public ILocator InventoryItemPrices => GetInventoryItems.Locator("xpath=//div[@class='inventory_item_price']");
        private ILocator InventorySortButton => _page.Locator("[data-test=\"product_sort_container\"]");

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
        public async Task ClickAddToProductButton(string productName)
        {
            varProductName = productName;
            await VarProductItemButton.ClickAsync();
        }

        /// <summary>
        /// Click Remove product button using name e.g. "Sauce Labs Fleece Jacket"
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public async Task ClickRemoveProductButton(string productName)
        {
            varProductName = productName;
            await VarProductItemButton.ClickAsync();
        }

        /// <summary>
        /// Click checkout/cart button
        /// </summary>
        /// <returns></returns>
        public async Task ClickCheckoutButton() => await CheckoutButton.ClickAsync();

        /// <summary>
        /// Get variable product text name for locator e.g. "Sauce Labs Backpack"
        /// </summary>
        /// <param name="productName"></param>
        public void GetVarProductNameForLocator(string productName) => varProductName = productName;

        /// <summary>
        /// Sorts products by Option value (string)
        /// </summary>
        /// <param name="sortName"></param>
        /// <returns></returns>
        public async Task ClickProductSortButton(string sortName) => await InventorySortButton.SelectOptionAsync(new[] { sortName });

        public async Task ClickVariableProductLink(string productName)
        {
            varProductName = productName;
            await VarProductItem.ClickAsync();
        }

        public async Task ClickAddToCartOnProductPage()
        {
            await AddToCartProductPage.ClickAsync();
        }
    }
}
