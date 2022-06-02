using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;

namespace AppiumMobileTests.ObjectForms
{
    public class ContactBookForm
    {
        private readonly AndroidDriver<AndroidElement> driver;

        public ContactBookForm(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public AndroidElement TextBoxContactBookAPI =>
            driver.FindElementById("contactbook.androidclient:id/editTextApiUrl");
        public AndroidElement ButtonConnect =>
            driver.FindElementById("contactbook.androidclient:id/buttonConnect");
        public AndroidElement TextBoxSearch =>
            driver.FindElementById("contactbook.androidclient:id/editTextKeyword");
        public AndroidElement ButtonSearch =>
            driver.FindElementById("contactbook.androidclient:id/buttonSearch");
        public AndroidElement ElementContactsCount =>
            driver.FindElementById("contactbook.androidclient:id/textViewSearchResult");
        public IReadOnlyCollection<AndroidElement> ElementFirstName =>
            driver.FindElementsById("contactbook.androidclient:id/textViewFirstName");
        public IReadOnlyCollection<AndroidElement> ElementLastName =>
            driver.FindElementsById("contactbook.androidclient:id/textViewLastName");

        public void SearchContact(string text)
        {
            TextBoxSearch.Clear();
            TextBoxSearch.SendKeys(text);

            ButtonSearch.Click();
        }

        public void ConnectToAPI()
        {
            TextBoxContactBookAPI.Clear();
            TextBoxContactBookAPI.SendKeys("https://contactbook.nakov.repl.co/api");

            ButtonConnect.Click();
        }
    }
}