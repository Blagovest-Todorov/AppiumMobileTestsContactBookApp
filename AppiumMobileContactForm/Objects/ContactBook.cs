using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;

namespace AppiumMobileContactBookApp.Objects
{
    public class ContactBook
    {
        //C:\contactbook-androidclient.apk
        private readonly AndroidDriver<AndroidElement> driver;
        private const string ApplicationUri = "https://contactbook.nakov.repl.co/api";

        public ContactBook(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        //AppServiceUri - > Locator ->contactbook.androidclient:id/editTextApiUrl
        public AndroidElement TextBoxContactBookAPIUri => driver.FindElementById("contactbook.androidclient:id/editTextApiUrl");

        //ConnectButton -> locator -> contactbook.androidclient:id/buttonConnect
        public AndroidElement ConnectButton => driver.FindElementById("contactbook.androidclient:id/buttonConnect");


        //textBoxSearchContactcts -> locator -> contactbook.androidclient:id/editTextKeyword
        public AndroidElement TextBoxSearchButton => driver.FindElementById("contactbook.androidclient:id/editTextKeyword");

        //SearchButton locator ->contactbook.androidclient:id/buttonSearch
        public AndroidElement SearchButton => driver.FindElementById("contactbook.androidclient:id/buttonSearch");

        // SearchResultField ->locator ->  contactbook.androidclient:id/textViewSearchResult
        public AndroidElement SearchResultField => driver.FindElementById("contactbook.androidclient:id/textViewSearchResult");

        //locating firstName of teh first Element in the Collection -> contactbook.androidclient:id/textViewFirstName
        public IReadOnlyCollection<AndroidElement> CollectionFirstNames => driver.FindElementsById("contactbook.androidclient:id/textViewFirstName");

       
        //locating lastName of each element in the collection -> contactbook.androidclient:id/textViewLastName
        public IReadOnlyCollection<AndroidElement> CollectionLastNames => driver.FindElementsById("contactbook.androidclient:id/textViewLastName");

        public void ConnectToApplicationUri() 
        {
            TextBoxContactBookAPIUri.Clear();
            TextBoxContactBookAPIUri.SendKeys(ApplicationUri);

            ConnectButton.Click();
        }

        public void SearchContacts(string contactText) 
        {
            TextBoxSearchButton.Clear();
            TextBoxSearchButton.SendKeys(contactText);
            SearchButton.Click();
        }
    }
}
