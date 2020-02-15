Feature: TablePagination
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CheckNumberOfRecords
Scenario: As a user i want to have in table 15 records, 5 one each page
	Given Go to table-pagination-demo page
	When I am on the first page
	And I am check if there is 5 record on first page
	Then Go to second Page
	When I am check if there is 5 record on second page
	Then Go to third Page
	When I am check if there is 5 record on third page
	
