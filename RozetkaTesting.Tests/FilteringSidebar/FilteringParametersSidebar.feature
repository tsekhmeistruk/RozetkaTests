﻿Feature: FilteringParametersSidebar
	In order to ckeck the filter functionality
	As a user
	I want to be able to filter results on the result page

@mytag
Scenario: Filter by price
	Given I'm on the Software page
	And I input min values and max values
	When I press ok button for submitting price filter
	Then the result page should contains goods which has appropriate price range
