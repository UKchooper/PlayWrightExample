using Microsoft.Playwright;

namespace PlayWrightSpecFlow.Pages
{
    public class CartPage
    {
        private readonly IPage _page;
        private string varProductName = "";

        public CartPage(IPage page) => _page = page;

        public ILocator VarProductItem => _page.GetByText(varProductName);
        public ILocator CheckoutCartNumber => _page.Locator("xpath=//div[@class='cart_item']");

        /// <summary>
        /// Get variable product text name for locator e.g. "Sauce Labs Backpack"
        /// </summary>
        /// <param name="productName"></param>
        public void GetVarProductNameForLocator(string productName)
        {
            varProductName = productName;
        }
    }
}
