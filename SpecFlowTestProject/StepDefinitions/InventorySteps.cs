using Microsoft.Playwright.NUnit;
using PlayWrightSpecFlow.Pages;
using PlayWrightSpecFlow.TableRows;
using SpecFlowTestProject.Drivers;
using SpecFlowTestProject.Pages;
using TechTalk.SpecFlow.Assist;

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

            await _inventoryPage.ClickAddToProductButton(productName);
            expectedButtonText.Should().Be(await _inventoryPage.VarProductItemButton.InnerTextAsync());
        }

        [When(@"I navigate to specific product page '([^']*)'")]
        public async Task WhenINavigateToSpecificProductPage(string productName)
        {
            _inventoryPage.GetVarProductNameForLocator(productName);
            await _inventoryPage.ClickVariableProductLink(productName);
        }

        [When(@"I click Add to cart button on product page for item")]
        public async Task WhenIClickAddToCartButtonOnProductPageForItem()
        {
            await _inventoryPage.ClickAddToCartOnProductPage();
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

        [Then(@"I click Remove button main page for '([^']*)' item")]
        public async Task ThenIClickRemoveButtonMainPageForItem(string productName)
        {
            var expectedButtonText = "Add to cart";

            await _inventoryPage.ClickRemoveProductButton(productName);
            expectedButtonText.Should().Be(await _inventoryPage.VarProductItemButton.InnerTextAsync());
        }

        [Then(@"I validate product Title <Title>, Description <Description> and Price <Price>")]
        public async Task ThenIValidateProductTitleTitleDescriptionDescriptionAndPricePrice(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            var price = data.Price;
            var productName = data.Title;

            _inventoryPage.GetVarProductNameForLocator(productName);

            var actual = await _inventoryPage.VarProductPriceText.InnerTextAsync();

            actual.Should().Be(price);
        }

        [When(@"I validate the order of products Title <Title>, Description <Description> and Price <Price>")]
        [Then(@"I validate the order of products Title <Title>, Description <Description> and Price <Price>")]
        public async Task ThenIValidateTheDefaultOrderOfProductsTitleTitleDescriptionDescriptionAndPricePrice(Table table)
        {
            List<ProductRow> product = new List<ProductRow>();
            product.AddRange(table.CreateSet<ProductRow>());

            // Get actual data
            var actualTitle = await _inventoryPage.InventoryItemTitles.AllInnerTextsAsync();
            var actualDescription = await _inventoryPage.InventoryItemDescriptions.AllInnerTextsAsync();
            var actualPrice = await _inventoryPage.InventoryItemPrices.AllInnerTextsAsync();

            for(var i = 0; i < product.Count(); i++)
            {
                actualTitle[i].Should().Be(product[i].Title);
                actualDescription[i].Should().Be(product[i].Description);
                actualPrice[i].Should().Be(product[i].Price);
            }

            //await _inventoryPage.TestingThisOut();
            //_driver.Page.Console += (_, msg) => Console.WriteLine(msg.Text);
        }

        [Then(@"I select Price \(low to high\) '([^']*)' from sort dropdown")]
        public async Task ThenISelectFromSortDropdown(string sortOptionName)
        {
            await _inventoryPage.ClickProductSortButton(sortOptionName);
        }
    }
}
