using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TestProjectUI.Pages.ActivityLog;

namespace TestProjectUI.PageSteps
{
    [Binding]
    public class ActivityLogStepDefinitions : BaseTest
    {
        private readonly ScenarioContext _scenarioContext;
        private ActivityLogPage _activityLog;
        public ActivityLogStepDefinitions(ScenarioContext scenarioContext) : base() 
        {
            _activityLog = new ActivityLogPage(Driver);
            _scenarioContext = scenarioContext;
        }

        [Given(@"I should be on the ActivityLog page")]
        public void GivenIShouldBeOnTheActivityLogPage()
        {
            _activityLog.IsDisplayed.Should().BeTrue("Activity log page cannot be displayed.");
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
            result.Should().BeTrue("Items have not been successfully deleted.");
        }

        [Given(@"I select '([^']*)' items from the list")]
        public void GivenISelectItemsFromTheList(string quantity)
        {
            IEnumerable<string> selectedItems = _activityLog.SelectItemsFromList(quantity);
            selectedItems.Count().Should().Be(int.Parse(quantity), "Not enauhg element to select.");
            _scenarioContext.Set(selectedItems, "ActivityLogItemsDelated");
        }
    }
}
