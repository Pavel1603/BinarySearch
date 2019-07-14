using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTest.Interfaces;
using BinarySearchTest.Models;

namespace BinarySearchTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // local master change
            // local dev
            TestProduct();
            Console.Read();
        }

        private static void TestProduct()
        {
            var products = new List<Product>();
            for (int i = 0; i < 100000; i++)
            {
                products.Add(new Product{Age = i, Id = i});
            }

            var sortedArray = products.ToArray();
            var valueToSearch = new Product{Age = 100, Id = 10000};
            var sw = Stopwatch.StartNew();

            TestSearchGeneric(sortedArray, valueToSearch);
            Console.WriteLine("Time: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("---------------------------");

            sw.Restart();
            TestBinarySearchGeneric(sortedArray, valueToSearch);
            Console.WriteLine("Time: {0}", sw.ElapsedMilliseconds);
        }

        private void TestInt()
        {
            var sortedArray = Enumerable.Range(0, 10000000).ToArray();
            var valueToSearch = 2999999;
            var sw = Stopwatch.StartNew();

            TestSearch(sortedArray, valueToSearch);
            Console.WriteLine("Time: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("---------------------------");

            sw.Restart();
            TestBinarySearch(sortedArray, valueToSearch);
            Console.WriteLine("Time: {0}", sw.ElapsedMilliseconds);
        }

        private static void TestSearchGeneric(Product[] sortedArray, Product valueToSearch)
        {
            var IterationCounter = 0;
            var index = -1;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                IterationCounter++;
                if (sortedArray[i].CompareTo(valueToSearch) == 0)
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine("FOREACH: SearchValue: {0}, FoundValue: {1}, Index: {2}, IterationCount: {3}", valueToSearch, index > 0 ? sortedArray[index].ToString() : "NaN", index, IterationCounter);
        }

        private static void TestBinarySearchGeneric(Product[] sortedArray, Product valueToSearch)
        {
            var bsh = new BinarySearchGenericHelper<Product>();
            var index = bsh.Search(sortedArray, valueToSearch, 0, sortedArray.Length - 1);
            Console.WriteLine("BINARY: SearchValue: {0}, FoundValue: {1}, Index: {2}, IterationCount: {3}", valueToSearch, index > 0 ? sortedArray[index].ToString() : "NaN", index, bsh.IterationCounter);
        }

        private static void TestBinarySearch(int[] sortedArray, int valueToSearch)
        {
            var bsh = new BinarySearchHelper();
            var index = bsh.Search(sortedArray, valueToSearch, 0, sortedArray.Length - 1);
            Console.WriteLine("BINARY: SearchValue: {0}, FoundValue: {1}, Index: {2}, IterationCount: {3}", valueToSearch, index > 0 ? sortedArray[index].ToString() : "NaN", index, bsh.IterationCounter);
        }

        private static void TestSearch(int[] sortedArray, int valueToSearch)
        {
            var IterationCounter = 0;
            var index = -1;
            foreach (var i in sortedArray)
            {
                IterationCounter++;
                if (i == valueToSearch)
                {
                    index = i;
                }
            }

            Console.WriteLine("FOREACH: SearchValue: {0}, FoundValue: {1}, Index: {2}, IterationCount: {3}", valueToSearch, index > 0 ? sortedArray[index].ToString() : "NaN", index, IterationCounter);
        }
    }
}
