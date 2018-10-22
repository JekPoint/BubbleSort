using NUnit.Framework;
using GnomeSort;

namespace GnomeSortTests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        [TestCase(City.Гоа)]
        [TestCase(City.Екат)]
        [TestCase(City.Москва)]
        [TestCase(City.Пермь)]
        [TestCase(City.Питер)]
        [TestCase(City.Тайланд)]
        public void CityIn_WhenSet_ResultExpected(City expectedValue)
        {
            var card = new Card()
            {
                CityIn = expectedValue
            };
            
            Assert.IsTrue(card.CityIn == expectedValue);
        }

        [Test]
        [TestCase(City.Гоа)]
        [TestCase(City.Екат)]
        [TestCase(City.Москва)]
        [TestCase(City.Пермь)]
        [TestCase(City.Питер)]
        [TestCase(City.Тайланд)]
        public void CityOut_WhenSet_ResultExpected(City expectedValue)
        {
            var card = new Card()
            {
                CityOut = expectedValue
            };

            Assert.IsTrue(card.CityOut == expectedValue);
        }

        [Test]
        public void CityIn_WhenSetInvalidValue_PropertyNotSet()
        {
            const City expectedValue = City.Гоа;
            var card = new Card()
            {
                CityIn = expectedValue
            };

            card.CityIn = (City)10;

            Assert.IsTrue(card.CityIn == expectedValue);
        }

        [Test]
        public void CityOut_WhenSetInvalidValue_PropertyNotSet()
        {
            const City expectedValue = City.Гоа;
            var card = new Card()
            {
                CityOut = expectedValue
            };

            card.CityOut = (City)10;

            Assert.IsTrue(card.CityOut == expectedValue);
        }
    }
}
