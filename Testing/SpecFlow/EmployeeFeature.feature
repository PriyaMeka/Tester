Feature: EmployeeFeature

As a TurnUp portal tester
I would like to create,edit and delete employee records.
check if it is done successfully.

@tag1
Scenario: Create employee record with valid details
	Given Logged into Turnup portal successfully.
	And   Navigate to employee page..
	When  I created a employee record.
	Then the record should be created successfully. 

Scenario: Edit employee record with valid details
	Given After creting a employee record successfully.
	And   Search for created employee record .
	When  I edited an existing employee record.
	Then the employee record should be edited successfully.

Scenario: Delete an existing employee record
	Given After editing an employee record successfully
	And   Search for the edited employee record..
	When  I delete an existing employee record .
	Then the employee record should be deleted successfully .