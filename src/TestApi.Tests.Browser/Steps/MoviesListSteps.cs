using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;

namespace TestApi.Tests.Browser.Steps
{
    [Binding]
    public class MoviesListSteps
    {
        private IWebDriver _webDriver;
        private WebDriverWait _wait;

        [BeforeScenario]
        public void SetupScenario()
        {
            _webDriver = new ChromeDriver();
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            _webDriver.Dispose();
        }

        [Given(@"my Movies website")]
        public void GivenMyMoviesWebsite()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:60000/");
        }
        
        [When(@"I navigate to the fetch data page")]
        public void WhenINavigateToTheFetchDataPage()
        {
            var element = _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("fetchdata")));
            element.Click();
        }
        
        [Then(@"I am presented with exactly (.*) movies")]
        public void ThenIAmPresentedWithExactlyMovies(int movieCount)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("movies-list")));
            
            var displayedMovieSCount = _webDriver.FindElements(By.CssSelector("table#movies-list tbody tr")).Count;
            Assert.That(displayedMovieSCount, Is.EqualTo(movieCount));
        }
    }
}
