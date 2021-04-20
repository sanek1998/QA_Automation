using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.Helper
{
    public static class WaiterByHelper
    {
        public static bool WaiterByElementIsDisplayed(this IWebDriver driver, By byClass)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver), "driver is null");
            }

            if (byClass is null)
            {
                throw new ArgumentNullException(nameof(byClass), "By is null");
            }

            var waiter = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));

            var element = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(byClass);
                    return elementToBeDisplayed.Displayed;
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
            return element;
        }
        
        public static bool WaiterByElementIsNotDisplayed(this IWebDriver driver, By byClass)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(nameof(driver), "driver is null");
            }

            if (byClass is null)
            {
                throw new ArgumentNullException(nameof(byClass), "By is null");
            }

            var waiter = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));

            var element = waiter.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElements(byClass);
                    return elementToBeDisplayed.Count==0;
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
            return element;
        }
    }
}