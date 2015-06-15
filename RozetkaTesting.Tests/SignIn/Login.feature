Feature: Login
	In order to check login functionality
	As a user
	I should not be able to login with invalid credentials
	And be able to login with valid credentials 

@login
Scenario: Login with incorrect password
	Given I am on the "SignIn" page
	And I enter a valid registered email and invalid password
	When I press Login button
	Then the invalid password warning is appear

@login
Scenario: Login with incorrect email
	Given I am on the "SignIn" page
	And I enter invalid registered email and invalid password
	When I press Login button
	Then the invalid email warning is appear

@login
Scenario: Login with valid credentials
	Given I am on the "SignIn" page
	And I enter valid registered email and valid password
	When I press Login button
	Then the "Profile" page is loaded