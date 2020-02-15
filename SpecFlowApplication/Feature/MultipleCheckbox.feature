Feature: MultipleCheckbox
		In this feature we are checking messages of "Basic first form demo" page

@MultipleCheckboxTest
Scenario: As User I in Checkbox Multiple form i want to have Uncheck all button when i select all checkbox
	Given I go to basic-first-form-demo.html page
	When I click all checkbox  button in multiple checkbox form
	Then the button should change text from "Check All" to "Uncheck All"
