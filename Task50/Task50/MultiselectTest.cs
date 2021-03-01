using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task50
{
    [TestFixture]
    public class MultiselectTest
    {
        private static readonly string URL = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver { Url = URL };
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
        }


        [Test]
        public void MultiSelectListTest()
        {
            var selected = new SelectElement(_driver.FindElement(By.Id("multi-select")));
            Assert.True(selected.IsMultiple, "Select list is not multiple");
            selected.SelectByValue("California");
            selected.SelectByValue("Florida");
            selected.SelectByValue("New York");

            var expectedSelection = new List<string>()
            {
                "California",
                "Florida",
                "New York"
            };

            List<string> actualSelection = new List<string>();

            foreach (var option in selected.AllSelectedOptions)
            {
                actualSelection.Add(option.Text);
            }

            CollectionAssert.AreEqual(expectedSelection, actualSelection, "Not all items were selected");
        }

        [Test]
        public void SelectListTest()
        {
            var selected = new SelectElement(_driver.FindElement(By.Id("select-demo")));

            selected.SelectByValue("Friday");
            var actualValue = selected.SelectedOption.Text;
            var expectedValue = "Friday";

            Assert.AreEqual(actualValue, expectedValue, "Element selected incorrectly");
        }

        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }
    }
}