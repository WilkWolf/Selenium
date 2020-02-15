Feature: BasicForm
		In this feature we are checking messages of "Basic first form demo" page

@MessageTest
Scenario: Enter message and check displayed value
	Given I enter to /test/basic-first-form-demo page
	And I have entered "Test" into the Enter message input
	When I click on Show Message button
	Then the result should be Your Message:"Test"