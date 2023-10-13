Feature: ActivityLog

In this feature files we verify all actions on ActivityLog module/page

Scenario: ActivityLog_01 Create contact and verify result
	Given I open the '<Browser>' browser
	And I navigate to the login page as 'Admin'
	And I navigate to 'Reports & Settings' from the header
	And I click on 'Activity log' in the header
	And I should be on the ActivityLog page
	And I select '3' items from the list
	And I click the 'Actions' button on left sidebar
	When I remove the selected items from the list
	Then I verify that the items have been successfully deleted

Examples: 
| Browser |
| Chrome  |