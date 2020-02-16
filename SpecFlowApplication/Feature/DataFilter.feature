Feature: DataFilter
	Check if all button show correct value

@FilterButtons
Scenario: As a user i want to select records in single color and all records by buttons.
	Given I go page to table-records-filter-demo.html page
	And I want to see 5 records
	When I click Green button
	Then I want to see two records with only green color
	When I click Orange button
	Then I want to see two records with only orange color
	When I click Red button
	Then I want to see one record with only red color
	When I click All button
	Then I want to see all records