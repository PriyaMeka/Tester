Feature: TimeandMaterialFeature

As a TurnUp portal tester
I would like to create,edit and delete time and material records.
check if it is done successfully.

@tag1
Scenario: Create time and material record with valid details
	Given Logged into turnup portal successfully 
	And   Navigate to time and material page..
	When  I created a time and material record.
	Then the record should be created successfully 

Scenario Outline: Edit existing time and material record with valid details
	Given Logged into turnup portal successfully 
	And   Navigate to time and material page..
	When  I update '<Description>' an existing time and material record.
	Then the record should have an updated '<Description>'.

	Examples: 
	| Description   |
	| Time          |
	| Material      |
	| Edited Record |

