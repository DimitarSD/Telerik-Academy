namespace FindProductInRange
{
    using System;
    using System.Diagnostics;

    public class StartUp
    {
        private const int NumberOfProducts = 500000;
        private const int NumberOfSearches = 10000;

        private static readonly Random RandomValue = new Random();
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public static void Main()
        {
            var store = new Store();

            Console.WriteLine("Please wait... \n");

            Stopwatch.Start();
            AddProducts(store); // 500 000 products
            Stopwatch.Stop();

            Console.WriteLine("Adding products...");
            Console.WriteLine("\rCount: {0} | Elapsed time: {1}\n", store.Products.Count, Stopwatch.Elapsed);

            Stopwatch.Restart();
            SearchInPriceRange(store); // 10 000 price searches
            Stopwatch.Stop();

            Console.WriteLine("Searching products");
            Console.WriteLine("Elapsed time: {0}\n", Stopwatch.Elapsed);
        }

        private static void AddProducts(Store store, int numOfProductsToAdd = NumberOfProducts)
        {
            for (int i = 0; i < numOfProductsToAdd; i++)
            {
                string name = RandomValue.Next(int.MaxValue).ToString();
                decimal price = RandomValue.Next(20000) / 100;
                var productToAdd = new Product(name, price);
                store.AddProduct(productToAdd);
            }
        }

        private static void SearchInPriceRange(Store store, int numOfSearches = NumberOfSearches)
        {
            for (int i = 0; i < numOfSearches; i++)
            {
                int min = RandomValue.Next(200);
                int max = RandomValue.Next(400, 1000);

                store.SearchInPriceRange(min, max);
            }
        }
    }
}
