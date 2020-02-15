Feature: AjaxForm
		In this feature we are checking messages of "Basic first form demo" page

@AjaxTest
Scenario: As User I go to Ajax page form demo and write "Test name" in "Name" field form and "Test comment" in "comment" field, when I click "submit" button I want to see text "Form submited Successfully" form
	Given I go page to ajax-form-submit-demo.html page
	And I have entered "Test name" into the Name input
	And I have entered "Test comment" into the Comment input
	When I click on Submit button
	And Wait 1 second
	Then the result should be "Form submited Successfully!"
