@inventory
Feature: Inventory tests

Inventory tests:
These include adding products to the cart, removing products from the cart

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

Scenario: Product title, descript, price are present and correct
	Given I navigate to website
	And I enter the login details 'standard_user' and 'secret_sauce'
	Then I validate product Title <Title>, Description <Description> and Price <Price>
		| Title                   | Description                                                                                                                                                     | Price  |
		| Sauce Labs Bolt T-Shirt | Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.                 | $15.99 |
		#| Sauce Labs Onesies      | Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel. | $7.99  |