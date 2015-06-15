Feature: Search
	In order to check search functionality
	As a user
	I want to find products accordingly to my search request

@search
Scenario Outline: Search products
	Given I am on the "Main" page
	When I enter search "<keyword>"
	And I press search button
	And the "Search Result" page is loaded
	And I click on the random product from the list of products on the Result page
	And the product description page is loaded
	Then the product category name should include the "<keyword>". 

	Examples: 
	|keyword	|
	|Велосипеды	|
	|Ноутбуки	|


