using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestProjectUI.Pages.Contacts;

namespace TestProjectUI.PageSteps
{
    [Binding]
    public class ActivityLogStepDefinitions : BaseTest
    {
        private readonly ScenarioContext _scenarioContext;
        private ActivityLog _activityLog;
        public ActivityLogStepDefinitions(ScenarioContext scenarioContext) : base() 
        {
            _activityLog = new ActivityLog(Driver);
            _scenarioContext = scenarioContext;
        }
           

        [Given(@"I should be on the ActivityLog page")]
        public void GivenIShouldBeOnTheActivityLogPage()
        {
            _activityLog.IsDisplayed.Should().BeTrue();
        }

        [Given(@"I click the '([^']*)' button on left sidebar")]
        public void GivenIClickTheButtonOnLeftSidebar(string actions)
        {
            _activityLog.ClickActionButton();
        }

        [When(@"I remove the selected items from the list")]
        public void WhenIRemoveTheSelectedItemsFromTheList()
        {
            _activityLog.DeleteFromList();
        }

        [Then(@"I verify that the items have been successfully deleted")]
        public void ThenIVerifyThatTheItemsHaveBeenSuccessfullyDeleted()
        {
            bool result = _activityLog.VerifyResult(_scenarioContext.Get<IEnumerable<string>>("ActivityLogItemsDelated"));
            result.Should().BeTrue();
        }

        [Given(@"I select '([^']*)' items from the list")]
        public void GivenISelectItemsFromTheList(string quantity)
        {
            IEnumerable<string> selectedItems = _activityLog.SelectItemsFromList(quantity);

            _scenarioContext.Set(selectedItems, "ActivityLogItemsDelated");
        }

    }
}
