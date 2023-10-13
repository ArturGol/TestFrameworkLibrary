Feature: Contacts

In this feature files we verify all actions on Contact module/page

Scenario: Contacts_01 Create contact and verify result
	Given I open the '<Browser>' browser
	And I navigate to the login page as 'Admin'
	And I navigate to 'Sales & Marketing' from the header
	And I click on 'Contacts' in the header
	And I should be on the Contacts page
	And I click the 'Create Contact' button in the left sidebar
	When I create contact from the file 'Contacts\TestUser.json'
	Then I verify that the contact data matches the file 'Contacts\TestUser.json'

Examples: 
| Browser |
| Chrome  |