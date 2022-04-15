using NUnit.Framework;
using Logic.interfaces;
using ProductApi.Controllers;
using Logic.repositories;
using Models.culture;
using Models.enums;
using Moq;

namespace ProductApi.Test
{
    public class CountryControllerTest
    {
        private static CountryController _mokCountroller;
        private static CountryController _countroller;
        Mock<IGenericRepositoryrReadable<Country>> mockRepository = new Mock<IGenericRepositoryrReadable<Country>>();
        private Country[] mokCountries = {
                new Country { id = 3, name = "Country 1", currency = Currencies.AUD, rate = (decimal)1.000 },
                new Country { id = 5, name = "Country 2", currency = Currencies.USD, rate = (decimal)0.742 },
                new Country { id = 6, name = "Country 3", currency = Currencies.USD, rate = (decimal)0.855 },
            };

        private Country mokCountry = new Country { id = 1, name = "Australia", currency = Currencies.AUD, rate = (decimal)1.000 };

        [SetUp]
        public void Setup()
        {

            mockRepository.Setup(m => m.GetAll()).Returns(mokCountries);
            mockRepository.Setup(m=>m.GetById(It.IsAny<int>())).Returns(mokCountry);

            _mokCountroller = new CountryController(mockRepository.Object);
            _countroller = new CountryController(new CountryRepository());
        }

        [Test]
        public void GetAllCountriesMokTest()
        {
            var result = _mokCountroller.GetAll();
            Assert.AreEqual(result.Count, mokCountries.Length);
            Assert.AreEqual(result[0].id, mokCountries[0].id);

        }

        [Test]
        public void GetCountryMokTest()
        {
            var result = _mokCountroller.Details(1);
            Assert.AreEqual(result.name, mokCountry.name);
        }

        [Test]
        public void GetAllCountriesUnitTest()
        {
            var result = _countroller.GetAll();
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].id, 1);

        }

        [Test]
        public void GetCountryLiveUitTest_valid()
        {
            var result = _countroller.Details(1);
            Assert.AreEqual(result.name, mokCountry.name);
        }

        [Test]
        public void GetCountryLiveUnitTest_inValid()
        {
            var result = _countroller.Details(10);
            Assert.IsNull(result);
        }
    }
}