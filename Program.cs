namespace Advanced_2
{
    #region Task
    //using System;
    //using System.Collections.Generic;
    //namespace ShopMaster
    //{

    //    // Starter Code: Data Models & Product Catalog

    //    public class Product
    //    {
    //        public int Id { get; set; }
    //        public string Name { get; set; }
    //        public string Category { get; set; }
    //        public double Price { get; set; }
    //        public int Stock { get; set; }
    //    }
    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {

    //            List<Product> catalog = new()
    //        {
    //            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
    //            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
    //            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
    //            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
    //            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
    //            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
    //            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
    //            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
    //            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
    //            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
    //        };

    //            // Task 01 : Smart Product Search Execution

    //            Console.WriteLine("--- Electronics ---");
    //            var electronics = SearchProducts(catalog, p => p.Category == "Electronics");
    //            electronics.ForEach(p => Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})"));

    //            Console.WriteLine("\n--- Under $50 ---");
    //            var under50 = SearchProducts(catalog, p => p.Price < 50);
    //            under50.ForEach(p => Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})"));

    //            Console.WriteLine("\n--- In Stock ---");
    //            var inStock = SearchProducts(catalog, p => p.Stock > 0);

    //            foreach (var p in inStock)
    //            {
    //                if (p.Id <= 4) 
    //                    Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
    //            }

    //            Console.WriteLine("\n--- Clothing Under $100 ---");
    //            var clothingUnder100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
    //            clothingUnder100.ForEach(p => Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})"));

    //            // Task 03.1 : Print Reports Execution

    //            Console.WriteLine("\n--- Short Report ---");

    //            PrintReport(catalog.GetRange(0, 6), p => Console.WriteLine($"{p.Name} - ${p.Price}"));

    //            Console.WriteLine("\n--- Detailed Report ---");
    //            PrintReport(catalog.GetRange(0, 7), p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

    //            // Task 03.2 : Transform Products Execution

    //            Console.WriteLine("\n--- Summary List ---");
    //            List<string> summaries = TransformProducts(catalog.GetRange(0, 7), p => $"{p.Name} (${p.Price})");
    //            summaries.ForEach(Console.WriteLine);

    //            Console.WriteLine("\n--- Price Labels ---");
    //            List<string> priceLabels = TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");

    //            foreach (var label in priceLabels)
    //            {
    //                if (label.StartsWith("Laptop") || label.StartsWith("Phone") || label.StartsWith("T-Shirt") ||
    //                    label.StartsWith("Novel") || label.StartsWith("Headphones") || label.StartsWith("Jacket"))
    //                {
    //                    Console.WriteLine(label);
    //                }
    //            }

    //            // Task 03.3 : Filter Products Execution

    //            Console.WriteLine("\n--- Low-Stock Alert ---");
    //            List<Product> lowStockProducts = FilterProducts(catalog, p => p.Stock < 20);
    //            lowStockProducts.ForEach(p => Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!"));
    //        }

    //        // Task Methods Implementation & Explanations

    //        /// <summary>
    //        /// Task 01: Evaluates data using a Func delegate.
    //        /// Delegate Used: Func<Product, bool>
    //        /// Why: It accepts a Product object as input and returns a boolean value (true/false). 
    //        /// This allows dynamic condition passing via lambda expressions without modifying the underlying search logic.
    //        /// </summary>
    //        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
    //        {
    //            List<Product> results = new List<Product>();
    //            foreach (var product in products)
    //            {
    //                if (filter(product))
    //                {
    //                    results.Add(product);
    //                }
    //            }
    //            return results;
    //        }

    //        /// <summary>
    //        /// Task 03.1: Performs an operation on data using an Action delegate.
    //        /// Delegate Used: Action<Product>
    //        /// Why: Action is used when we want to execute a process (like rendering text to the console) 
    //        /// that performs an operation on an object but returns 'void'.
    //        /// </summary>
    //        public static void PrintReport(List<Product> products, Action<Product> reportAction)
    //        {
    //            foreach (var product in products)
    //            {
    //                reportAction(product);
    //            }
    //        }

    //        /// <summary>
    //        /// Task 03.2: Maps/Transforms data objects using a Func delegate.
    //        /// Delegate Used: Func<Product, string>
    //        /// Why: We need to project a Product instance into a formatted string layout. 
    //        /// Func handles input parameters and ensures a transformed data result is explicitly returned.
    //        /// </summary>
    //        public static List<string> TransformProducts(List<Product> products, Func<Product, string> transformer)
    //        {
    //            List<string> transformedList = new List<string>();
    //            foreach (var product in products)
    //            {
    //                transformedList.Add(transformer(product));
    //            }
    //            return transformedList;
    //        }

    //        /// <summary>
    //        /// Task 03.3: Filters data using a Predicate delegate.
    //        /// Delegate Used: Predicate<Product>
    //        /// Why: Predicate is a specialized, built-in C# delegate structurally identical to Func<T, bool>. 
    //        /// It is explicitly designed to check if a specific object matches a defined criteria.
    //        /// </summary>
    //        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> matchCondition)
    //        {
    //            List<Product> matchedList = new List<Product>();
    //            foreach (var product in products)
    //            {
    //                if (matchCondition(product))
    //                {
    //                    matchedList.Add(product);
    //                }
    //            }
    //            return matchedList;
    #endregion
}
        }
    }
}
    


