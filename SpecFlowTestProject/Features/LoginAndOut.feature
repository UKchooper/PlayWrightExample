@login
Feature: Login tests

Scenario: Test invalid login operation of Swag labs website
	Given I navigate to website
	When I enter the login details '<UserName>' and '<Password>'
	Then I valiate the login error '<Error>'

Examples:
	| UserName        | Password       | Error                                                                     |
	|                 |                | Epic sadface: Username is required                                        |
	|                 | RandomPassword | Epic sadface: Username is required                                        |
	| RandomUser      |                | Epic sadface: Password is required                                        |
	| standard_user   |                | Epic sadface: Password is required                                        |
	| RandomUser      | RandomPassword | Epic sadface: Username and password do not match any user in this service |
	| standard_user   | RandomPassword | Epic sadface: Username and password do not match any user in this service |
	| locked_out_user | secret_sauce   | Epic sadface: Sorry, this user has been locked out.                       |

Scenario: Test Valid login operation of Swag labs website and log out
	Given I navigate to website
	When I enter the login details 'standard_user' and 'secret_sauce'
	Then I validate the url 'https://www.saucedemo.com/inventory.html'
	And I select user log out
	And I validate the url 'https://www.saucedemo.com/'
	