using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;

namespace AppiumMobileTests.Tests
{
    public class ContactBookBaseTest
    {
        private const string AppiumServerUri = "http://127.0.0.1:4723/wd/hub";
        private const string AppPath = @"C:\contactbook-androidclient.apk";
        protected AndroidDriver<AndroidElement> driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", AppPath);
            driver = new AndroidDriver<AndroidElement>(
                new Uri(AppiumServerUri), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void ShutDown()
        {
            driver.Quit();
        }
    }
}