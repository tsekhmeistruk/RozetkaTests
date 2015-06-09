Feature: CartChecking
	In order to	check Cart basic functionality
	As a common user without registration
	I want to be able to add products to my cart.

@cart
Scenario: Add product to my cart
	Given I'm on the Software page
	When I add random product to my cart
	And I am on the Cart page
	Then I should see the product which I have added before
