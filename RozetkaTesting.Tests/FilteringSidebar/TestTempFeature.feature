Feature: TestTempFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add product to the cart
	Given I'm on the Software page
	When I add random product to the cart
	Then I have a product in cart with specific price
