@inventory
Feature: Inventory tests

A short summary of the feature

Scenario: Item can be added to cart
	Given I navigate to website
	And I enter the login details 'standard_user' and 'secret_sauce'
	When I click Add to cart button on main page for 'Sauce Labs Backpack' item
	Then I navigate to checkout
	And validate '1' 'Sauce Labs Backpack' item is in cart
