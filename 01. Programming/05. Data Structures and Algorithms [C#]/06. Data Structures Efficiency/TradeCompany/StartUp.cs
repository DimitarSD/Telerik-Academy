namespace TradeCompany
{
    using System;
    using System.Diagnostics;

    public class StartUp
    {
        private const int NumberOfProductsToAdd = 500000;
        private const int NumberOfPriceSearches = 5000000;

        private static readonly Random RandomValue = new Random();
        private static readonly Stopwatch StopWatch = new Stopwatch();

        public static void Main()
        {
            var store = new Store();

            Console.Write("Please wait... ");

            StopWatch.Start();
            AddProducts(store); // 500 000 products
            StopWatch.Stop();

            Console.WriteLine("\rAdding products -> Elapsed time: {0}", StopWatch.Elapsed);

            StopWatch.Restart();
            SearchProductsInPriceRange(store); // 5 000 000 price searches
            StopWatch.Stop();

            Console.WriteLine("\nSearching products -> Elapsed time: {0}\n", StopWatch.Elapsed);
        }

        private static void AddProducts(Store store, int numOfProductsToAdd = NumberOfProductsToAdd)
        {
            for (int i = 0; i < numOfProductsToAdd; i++)
            {
                string title = RandomValue.Next(int.MaxValue).ToString();
                decimal price = RandomValue.Next(20000) / 100;
                var product = new Product(title, price);
                store.AddProduct(product);
            }
        }

        private static void SearchProductsInPriceRange(Store store, int numOfProductsToSearch = NumberOfPriceSearches)
        {
            for (int i = 0; i < numOfProductsToSearch; i++)
            {
                int min = RandomValue.Next(200), max = RandomValue.Next(250, 2000);
                store.SearchInPriceRange(min, max);
            }
        }
    }
}
