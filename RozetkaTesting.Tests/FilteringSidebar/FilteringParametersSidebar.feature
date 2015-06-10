Feature: FilteringParametersSidebar
	In order to ckeck the filter functionality
	As a user
	I want to be able to filter results on the result page

@filter
Scenario: Filter by price
	Given I am on the Software page
	And I enter random min values and max values into 'price filter form' from range of possible values
	When I press ok button for submitting price filter
	Then The result page should contains goods which has appropriate price range

