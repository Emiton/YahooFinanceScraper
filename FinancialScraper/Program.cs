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

                // Click the sign in button
                driver.FindElement(By.Id("uh-signedin")).Click();

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                // Find username login
                IWebElement email = driver.FindElement(By.Id("login-username"));
                email.SendKeys("YOUR_EMAIL");
                try
                {
                    driver.FindElement(By.XPath("//*[@id=\"login-signin\"]")).Click();
                }
                catch (Exception e)
                {
                    Console.WriteLine("IT WAS NEVER CLICKED!");
                }

                Console.WriteLine("I GUESS WE CLICKED SOMETHING!");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                // Find password input
                IWebElement password = driver.FindElement(By.Id("login-passwd"));

                password.SendKeys("YOUR_PASSWORD");
                driver.FindElement(By.Id("login-signin")).Click();



                // *A* Click the link to 'My Portfolio'
                //driver.FindElement(By.XPath("//a[@href='/portfolios?bypass=true']")).Click();

                //try
                //{
                //    // *B* Click the sign in button
                //    driver.FindElement(By.XPath("//*[@id='uh']/header/section/div[2]/a")).Click();
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("IT NEVER FOUND THE SIGN IN BUTTON");
                //}
                // Reverse A and B
            }
        }
    }
}
