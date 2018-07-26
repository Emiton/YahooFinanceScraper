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


                // Find username login
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                IWebElement email = driver.FindElement(By.Id("login-username"));
                email.SendKeys("financetester321@gmail.com");
                driver.FindElement(By.XPath("//*[@id=\"login-signin\"]")).Click();

                Console.WriteLine("GOT THE EMAIL BABAYYYY!");


                // Find password input
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                IWebElement password = driver.FindElement(By.Id("login-passwd"));
                password.SendKeys("thisisnew1234");
                driver.FindElement(By.Id("login-signin")).Click();
                Console.WriteLine("WE LOGGED IN!");

                // Navigate to Homepage
                driver.FindElement(By.XPath("//*[@id=\"Nav-0-DesktopNav\"]/div/div[3]/div/div[1]/ul/li[2]/a")).Click();

                // Wait for pop-up then disable
                var alert = driver.FindElement(By.XPath("//dialog[@id = '__dialog']/section/button"));
                alert.Click();

                // Navigate to Portfolio
                driver.FindElement(By.XPath("//*[@id=\"main\"]/section/section/div[2]/table/tbody/tr[1]/td[1]/a")).Click();

                driver.Manage().Window.Maximize();
                Console.WriteLine("Ready to extract data");

                // GET INFO METHOD 1
                //var table = driver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody"));
                //var i = 1;
                //foreach (var row in table.FindElements(By.TagName("tr")))
                //{
                //    Console.WriteLine("STOCK # " + i);
                //    foreach (var info in row.FindElements(By.TagName("td")))
                //    {
                //        Console.WriteLine(info.Text);
                //    }
                //    i++;
                //}

                // GET INFO METHOD 2
                //var stocks = driver.FindElements(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[*]/td[*]"));
                //foreach (var stock in stocks)
                //    Console.WriteLine(stock.Text);


                // GET INFO METHOD 3
                // If info is not nested in <td>, then this method will not extract said info
                //var table = driver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody"));
                //var rows = table.FindElements(By.TagName("tr"));
                //foreach (var row in rows)
                //{
                //    var columns = driver.FindElements(By.TagName("td"));
                //    foreach (var column in columns)
                //    {
                //        Console.WriteLine(column.Text);
                //    }
                //}

            }
        }
    }
}
