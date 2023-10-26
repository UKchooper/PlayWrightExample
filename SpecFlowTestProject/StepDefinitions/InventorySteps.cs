using Microsoft.Playwright.NUnit;
using PlayWrightSpecFlow.Pages;
using SpecFlowTestProject.Drivers;
using SpecFlowTestProject.Pages;

namespace SpecFlowTestProject.StepDefinitions
{
    [Binding]
    public class InventorySteps : PageTest
    {
        private readonly Driver _driver;
        private readonly InventoryPage _inventoryPage;
        private readonly CartPage _cartPage;

        public InventorySteps(Driver driver)
        {
            _driver = driver;
            _inventoryPage = new InventoryPage(_driver.Page);
            _cartPage = new CartPage(_driver.Page);
        }

        [When(@"I click Add to cart button on main page for '([^']*)' item")]
        public async Task WhenIClickAddToCartButtonOnMainPageForItem(string productName)
        {
            var expectedButtonText = "Remove";

            await _inventoryPage.ClickAddToProduct(productName);
            expectedButtonText.Should().Be(await _inventoryPage.VarProductItemButton.InnerTextAsync());
            
        }

        [Then(@"I navigate to checkout")]
        public async Task ThenINavigateToCheckout()
        {
            var expectedUrl = "https://www.saucedemo.com/cart.html";

            await _inventoryPage.ClickCheckoutButton();
            await Expect(_driver.Page).ToHaveURLAsync(expectedUrl);
        }

        [Then(@"validate '([^']*)' '([^']*)' item is in cart")]
        public async Task ThenValidateItemIsInCart(int productCount, string productName)
        {
            _cartPage.GetVarProductNameForLocator(productName);

            productCount.Should().Be(await _cartPage.CheckoutCartNumber.CountAsync());
            productName.Should().Be(await _cartPage.VarProductItem.InnerTextAsync());
        }
    }
}
