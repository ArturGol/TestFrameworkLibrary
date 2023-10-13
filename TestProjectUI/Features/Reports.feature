Feature: Reports

In this feature files we verify all actions on Report module/page

Scenario: Reports_01 Run report and verify result
Given I open the '<Browser>' browser
	And I navigate to the login page as 'Admin'
	And I navigate to 'Reports & Settings' from the header
	And I click on 'Reports' in the header
	And I should be on the Reports page
	When I find the 'Project Profitability' report
	Then I verify if any results are returned

Examples: 
| Browser |
| Chrome  |