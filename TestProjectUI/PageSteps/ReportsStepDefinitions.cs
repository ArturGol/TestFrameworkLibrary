using FluentAssertions;
using TechTalk.SpecFlow;
using TestProjectUI.Pages.Reports;

namespace TestProjectUI.PageSteps
{
    [Binding]
    public class ReportsStepDefinitions : BaseTest
    {
        private ReportsPage _reportsPage;

        public ReportsStepDefinitions()
        {
            _reportsPage = new ReportsPage(Driver);
        }

        [When(@"I find the '([^']*)' report")]
        public void WhenIFindReport(string reportName)
        {
            _reportsPage.FindReport(reportName);
            _reportsPage.RunReport();
        }

        [Then(@"I verify if any results are returned")]
        public void ThenIVerifyIfAnyData()
        {
            _reportsPage.IsAnyData().Should().BeTrue("There are no reports returned.");
        }

        [Given(@"I should be on the Reports page")]
        public void GivenIAmOnContactsPage()
        {
            _reportsPage.IsDisplay.Should().BeTrue("Cannot diplay report page.");
        }
    }
}
