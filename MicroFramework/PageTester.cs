using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MicroFramework.Commands;
using System.Diagnostics;

namespace MicroFramework
{
    /// <summary>
    /// Class for testing page.
    /// </summary>
    class PageTester
    {
        static PageTester pageTester;

        /// <summary>
        /// Get Pagetester.
        /// </summary>
        public static PageTester Get
        {
            get
            { return pageTester ?? (pageTester = new PageTester()); }
        }
        protected PageTester()
        { }
        
        IWebDriver driver = new ChromeDriver();
        
        ~PageTester()
        {
            driver.Dispose();
        }

        /// <summary>
        /// Testing open page with specified url and timeout.
        /// </summary>
        /// <param name="test">test</param>
        public void Open(Test test)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            driver.Navigate().GoToUrl(test.FirstParam);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(test.SecondParam);
            string locator = @"*[@id=""main-message""]";
            bool isSuccess = driver.FindElements(By.XPath(locator)).Count == 0;
            stopWatch.Stop();
            test.SetResult(stopWatch.Elapsed, isSuccess);
        }

        /// <summary>
        /// Testing check link by href.
        /// </summary>
        /// <param name="test">test</param>
        public void CheckLinkPresentByHref(Test test)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string locator = $"//a[@href='{test.FirstParam}']";
            bool isSuccess = driver.FindElements(By.XPath(locator)).Count != 0;

            stopWatch.Stop();
            test.SetResult(stopWatch.Elapsed, isSuccess);
         }

        /// <summary>
        /// Testing check link by name.
        /// </summary>
        /// <param name="test">test</param>
        public void CheckLinkPresentByName(Test test)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool isSuccess = driver.FindElements(By.PartialLinkText(test.FirstParam)).Count != 0;

            stopWatch.Stop();
            test.SetResult(stopWatch.Elapsed, isSuccess);
        }

        /// <summary>
        /// Testing page title.
        /// </summary>
        /// <param name="test">text</param>
        public void CheckPageTitle(Test test)
        {
            Stopwatch stopWatch = new Stopwatch();
            bool isSuccesed = false;
            stopWatch.Start();
            if (driver.Title == test.FirstParam)
            {
                isSuccesed = true;
            }
            stopWatch.Stop();
            test.SetResult(stopWatch.Elapsed, isSuccesed);
        }

        /// <summary>
        /// Testing page contains.
        /// </summary>
        /// <param name="test">test</param>
        public void CheckPageContains(Test test)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool isSuccesed = false;
            if (driver.PageSource.Contains(test.FirstParam))
            {
                isSuccesed = true;
            }
            stopWatch.Stop();
            test.SetResult(stopWatch.Elapsed, isSuccesed);
        }
    }
}
