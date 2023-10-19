Feature: EAEAppTest

@smoke
Scenario: Test Login operation of EA Application
	Given I navigate to application
	And I click login link
	And I enter following login details
	| UserName | Password |
	| admin    | passowrd |
	Then I see Employee Lists