using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;

namespace AppiumMobileContactBookApp.Tests
{
    public class BaseTestContactBook
    {
        //ServerURL
        private const string AppiumServerURI = "http://127.0.0.1:4723/wd/hub";

        //Application Path
        private const string ApplicationPath = @"C:\contactbook-androidclient.apk";

        // declare driver
        protected AndroidDriver<AndroidElement> driver;

        private WebDriverWait wait;


        [SetUp]
        public void SetUp() 
        {
            AppiumOptions options = new AppiumOptions() {PlatformName = "Android"};
            options.AddAdditionalCapability("app", ApplicationPath);

            driver = new AndroidDriver<AndroidElement>(new Uri(AppiumServerURI), options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown() 
        {
            driver.Quit();
        }
    }
}
