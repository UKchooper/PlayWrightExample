@inventory
Feature: Inventory tests

Inventory tests:
These include adding products to the cart, removing products from the cart, re-ordering items

Scenario: Item can be added to cart
	Given I navigate to website
	And I enter the login details 'standard_user' and 'secret_sauce'
	When I click Add to cart button on main page for 'Sauce Labs Backpack' item
	Then I navigate to checkout
	And validate '1' 'Sauce Labs Backpack' item is in cart

Scenario: Item can be removed via Inventory page
	Given I navigate to website
	And I enter the login details 'standard_user' and 'secret_sauce'
	When I click Add to cart button on main page for 'Sauce Labs Fleece Jacket' item
	Then I click Remove button main page for 'Sauce Labs Fleece Jacket' item

Scenario: Product title, description, price are present and correct
	Given I navigate to website
	And I enter the login details 'standard_user' and 'secret_sauce'
	Then I validate product Title <Title>, Description <Description> and Price <Price>
		| Title                   | Description                                                                                                                                     | Price  |
		| Sauce Labs Bolt T-Shirt | Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt. | $15.99 |

Scenario: Products can be re-ordered
	Given I navigate to website
	And I enter the login details 'standard_user' and 'secret_sauce'
	When I validate the order of products Title <Title>, Description <Description> and Price <Price>
		| Title                             | Description                                                                                                                                                            | Price  |
		| Sauce Labs Backpack               | carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.                                 | $29.99 |
		| Sauce Labs Bike Light             | A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.        | $9.99  |
		| Sauce Labs Bolt T-Shirt           | Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.                        | $15.99 |
		| Sauce Labs Fleece Jacket          | It's not every day that you come across a midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office. | $49.99 |
		| Sauce Labs Onesie                 | Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.        | $7.99  |
		| Test.allTheThings() T-Shirt (Red) | This classic Sauce Labs t-shirt is perfect to wear when cozying up to your keyboard to automate a few tests. Super-soft and comfy ringspun combed cotton.              | $15.99 |
	Then I select Price (low to high) 'lohi' from sort dropdown
	And I validate the order of products Title <Title>, Description <Description> and Price <Price>
		| Title                             | Description                                                                                                                                                            | Price  |
		| Sauce Labs Onesie                 | Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.        | $7.99  |
		| Sauce Labs Bike Light             | A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.        | $9.99  |
		| Sauce Labs Bolt T-Shirt           | Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.                        | $15.99 |
		| Test.allTheThings() T-Shirt (Red) | This classic Sauce Labs t-shirt is perfect to wear when cozying up to your keyboard to automate a few tests. Super-soft and comfy ringspun combed cotton.              | $15.99 |
		| Sauce Labs Backpack               | carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.                                 | $29.99 |
		| Sauce Labs Fleece Jacket          | It's not every day that you come across a midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office. | $49.99 |
		
		
	
