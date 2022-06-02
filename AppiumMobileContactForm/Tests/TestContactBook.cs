using AppiumMobileContactBookApp.Objects;
using NUnit.Framework;
using System.Linq;
using System.Threading;

namespace AppiumMobileContactBookApp.Tests
{
    public class TestContactBook : BaseTestContactBook
    {

        [Test]
        public void Test_SearchContact_ByValidName_Steve()
        {

            var windowContactBook = new ContactBook(driver);
            windowContactBook.ConnectToApplicationUri();
            var expectedInputName = "Steve";

            windowContactBook.SearchContacts(expectedInputName);
            Thread.Sleep(1000);

            var firstName = windowContactBook.CollectionFirstNames.First().Text;

            Assert.AreEqual(expectedInputName, firstName);

            var lastName = windowContactBook.CollectionLastNames.First().Text;
            var expectedLastName = "Jobs";

            Assert.AreEqual(expectedLastName, lastName);

            string actualResult = "Contacts found: " + windowContactBook.CollectionFirstNames.Count;

            Assert.AreEqual("Contacts found: 1", actualResult);
        }

        [Test]
        public void Test_FindContactsByValidLetter_e()
        {
            var windowContactBook = new ContactBook(driver);
            windowContactBook.ConnectToApplicationUri();

            string inputLetter = "e";
            windowContactBook.SearchContacts(inputLetter);

            Thread.Sleep(1000);
            string firstName = windowContactBook.CollectionFirstNames.Last().Text;
            string expectedFirstName = "Albert";

            Assert.AreEqual(expectedFirstName, firstName);

            string lastName = windowContactBook.CollectionLastNames.Last().Text;

            string expectedLastName = "Einstein";

            Assert.AreEqual(expectedLastName, lastName);

            var expectedResultFoundContacts = "Contacts found: 3";
            string actualResultContactsFound = "Contacts found: " + windowContactBook.CollectionFirstNames.Count.ToString();

            Assert.AreEqual(expectedResultFoundContacts, actualResultContactsFound);

        }

        [Test]
        public void Test_SearchContact_With_InvalidNameOrLetter() 
        {
            var windowContactBook = new ContactBook(driver);
            windowContactBook.ConnectToApplicationUri();

            var searchInput = "qqq";
            windowContactBook.SearchContacts(searchInput);
            Thread.Sleep(1000);

            string expectedResult = "Contact found: 0";
            string actualResult = "Contact found: " + windowContactBook.CollectionFirstNames.Count.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
