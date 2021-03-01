using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework.Constraints;
using Task50.Model;

namespace Task50
{
    [TestFixture]
    public class TableSortAndSearchDemoTest
    {
        private static readonly string URL = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";
        private IWebDriver _driver;
        private const int AgeFilter = 50;
        private const int SalaryFilter = 250000;
        private const string SelectedValue = "10";
        private IEnumerable<Employee> _employees = new List<Employee>();

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver { Url = URL };
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(9);
        }

        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }

        [Test]
        public void EmployeesFilterByAgeAndSalaryTest()
        {
            var select = new SelectElement(_driver.FindElement(By.XPath("//select")));
            Assert.False(select.IsMultiple);
            select.SelectByValue(SelectedValue);
            var expectedOption = SelectedValue;
            var actualOption = _driver.FindElement(By.XPath("//option[@value='10']")).Text;
            Assert.AreEqual(expectedOption, actualOption, "Element selected incorrectly");

            var countOfPage =
                _driver.FindElements(By.CssSelector("#example_paginate span a")).Count;
            Assert.True(countOfPage > 0);


            _employees = GrabAllDataFromAllPages(countOfPage).Where(emp => emp.Age > AgeFilter
                                                                           && emp.Salary <= SalaryFilter);
            Assert.True(_employees.Any(), "The list is empty");
        }

        private IEnumerable<Employee> GrabAllDataFromAllPages(int countOfPage)
        {
            List<Employee> allData = new List<Employee>();

            for (var i = 1; i <= countOfPage; i++)
            {
                _driver.FindElement(By.XPath("//a[@data-dt-idx='" + $"{i}" + "']")).Click();
                if (WaitUntilTablesNotEmpty())
                {
                    ReadOnlyCollection<IWebElement> trElements =
                        _driver.FindElements(By.CssSelector("#example tbody tr"));
                    IEnumerable<Employee> employeesFromPage = trElements.Select(employee => new Employee
                    {
                        Name = employee.FindElement(By.XPath("td[1]")).GetAttribute("data-search"),
                        Position = employee.FindElement(By.XPath("td[2]")).Text,
                        Office = employee.FindElement(By.XPath("td[3]")).Text,
                        Age = uint.TryParse(employee.FindElement(By.XPath("td[4]")).Text,
                            out var age)
                            ? age
                            : throw new ArgumentException("Cannot convert from string to integer."),

                        Salary = decimal.TryParse(employee.FindElement(By.XPath("td[6]")).GetAttribute("data-order"),
                            out var salary)
                            ? salary
                            : throw new ArgumentException("")
                    });
                    allData.AddRange(employeesFromPage);
                }
            }

            Assert.True(allData.Any(), "The list is empty");
            return allData;
        }

        public bool WaitUntilTablesNotEmpty()
        {
            var waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            return waiter.Until(condition =>
            {
                try
                {
                    ReadOnlyCollection<IWebElement> trElements =
                        _driver.FindElements(By.CssSelector("#example tbody tr"));
                    Assert.True(trElements.Any());
                    return trElements.Any();
                }
                catch (InvalidElementStateException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
    }
}