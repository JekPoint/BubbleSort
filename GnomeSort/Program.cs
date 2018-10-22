using System;
using System.Collections.Generic;
using System.Linq;

namespace GnomeSort
{
    public enum City { Москва, Пермь, Питер, Екат, Гоа, Тайланд };

    public class Program
    {
        static void Main(string[] args)
        {
            var routeCards = CreateRoute();
            PrintRoute(routeCards, "Befor");
            var sortedRouteCards = BubbleSort(routeCards);
            PrintRoute(sortedRouteCards, "After");
            Console.ReadLine();
        }

        static IEnumerable<string> AddAllFrom(HashSet<char> chars, int n)
        {
            if (n == 0)
                yield return "";
            foreach (var c in chars.ToList())
            {
                chars.Remove(c);
                foreach (var s in AddAllFrom(chars, n - 1))
                    yield return c + s;
                chars.Add(c);
            }
        }


        public static List<Card> CreateRoute()
        {
            var availableCities = Enum.GetNames(typeof(City));

            var random = new Random();
            var route = new List<Card>();
            while (true)
            {
                if (route.Count == availableCities.Length)
                    return route;

                var randomIndexIn = random.Next(0, availableCities.Length);
                var randomIndexOut = random.Next(0, availableCities.Length);

                if(randomIndexIn == randomIndexOut)
                    continue;

                var newRoute = new Card()
                {
                    CityIn = (City)randomIndexIn,
                    CityOut = (City)randomIndexOut
                };

                if(route.Exists(rout => rout == newRoute))
                    continue;

                if(route.Exists(rout => rout.CityIn == newRoute.CityIn))
                    continue;

                if(route.Exists(rout => rout.CityOut == newRoute.CityOut))
                    continue;

                if (route.Exists(rout => rout.CityOut == newRoute.CityIn && rout.CityIn == newRoute.CityOut))
                    continue;

                route.Add(newRoute);
            }
        }

        public static IList<Card> BubbleSort(IList<Card> routeCards)
        {
            var sortedRouteCards = new List<Card> {routeCards[0]};
            for (var i = 0; i < routeCards.Count - 1; i++)
            {
                for (var j = i; j < routeCards.Count - 1; j++)
                {
                    if ((int) routeCards[i].CityOut == (int) routeCards[i + 1].CityIn)
                    {
                        continue;
                    }
                    var temp = routeCards[i + 1];
                    routeCards[i + 1] = routeCards[j + 1];
                    routeCards[j + 1] = temp;
                }
            }

            for (var index = 0; index < routeCards.Count - 1; index++)
            {
                if (routeCards[index].CityOut == routeCards[index + 1].CityIn)
                    sortedRouteCards.Add(routeCards[index + 1]);
                else
                    return sortedRouteCards;
            }
            return sortedRouteCards;
        }

        private static void PrintRoute(IList<Card> routeCards, string message)
        {
            Console.WriteLine(message);
            foreach (var card in routeCards)
            {
                Console.Write($"->{card.CityIn}->{card.CityOut}");
            }
            Console.WriteLine();
        }
    }
}
