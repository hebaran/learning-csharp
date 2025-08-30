using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ProductsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<(string name, double price, int amount)>(5)
            {
                ("Mouse",     80.0,  5),
                ("Teclado",   150.0, 2),
                ("Monitor",   900.0, 1),
                ("Cabo HDMI", 50.0, 10),
                ("Headset",   200.0, 3)
            };

            var highestProducts = products.Where(product => product.price >= 100).Take(2).ToList();
            var finalProducts = GetHighestProducts(highestProducts);

            foreach (var product in finalProducts)
            {
                string productName = product.name;
                double totalValue = product.totalValue;

                Console.WriteLine($"{productName}: {FormatMoney(totalValue)}");
            }
        }

        static List<(string name, double totalValue)> GetHighestProducts(List<(string name, double price, int amount)> products)
        {
            var productsResponse = new List<(string name, double totalValue)>(products.Count);

            foreach (var product in products)
            {
                var formattedProduct = (name: product.name, totalValue: product.price * product.amount);
                productsResponse.Add(formattedProduct);
            }

            return productsResponse;
        }

        static string FormatMoney(double value)
        {
            string formattedValue = value.ToString("C", new CultureInfo("pt-BR"));
            return formattedValue;
        }
    }
}
