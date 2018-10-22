using System.Linq;
using GnomeSort;
using NUnit.Framework;

namespace GnomeSortTests
{
    class PropgramTests
    {
        [Test]
        public void CreateRoute_WhenCalled_ResultUnsorted()
        {
            var result = Program.CreateRoute();

            var sorted = true;

            for (var index = 0; index < result.Count - 1; index++)
            {
                if (result[index].CityOut != result[index + 1].CityIn)
                    sorted = false;
            }

            Assert.IsFalse(sorted);
        }

        [Test]
        public void BubbleSort_WhenCalled_ResultSorted()
        {
            var resultUnsortedCards = Program.CreateRoute();
            var sortedCards = Program.BubbleSort(resultUnsortedCards);
            var sorted = true;

            for (var index = 0; index < sortedCards.Count - 1; index++)
            {
                if (sortedCards[index].CityOut != sortedCards[index + 1].CityIn)
                    sorted = false;
            }

            Assert.IsTrue(sorted);
        }
    }
}
