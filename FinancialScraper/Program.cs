using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FinancialScraper
{
    class YahooScraper
    {
        static void Main(string[] args)
        {
            // Create a new chrome driver
            using (IWebDriver driver = new ChromeDriver())
            {
                // Go to main page
                driver.Navigate().GoToUrl("https://finance.yahoo.com");

                // *A* Click the link to 'My Portfolio'
                driver.FindElement(By.XPath("//a[@href='/portfolios?bypass=true']")).Click();

                // *B* Click the sign in button
                driver.FindElement(By.XPath("//*[@id='uh']/header/section/div[2]/a")).Click();

                // Reverse A and B
            }
        }
    }
}
