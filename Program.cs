using System.Linq;
using System;
using System.IO;

namespace Investments
{
    class Program
    {
        static void Main(string[] args)
        {
            var stockData = File.ReadAllLines("Moving-averages.csv")
                .Skip(1)
                .Select(row => new WeeklyValue(row))
                .Where(weeklyValue => weeklyValue.DerivativeDifference != null)
                .ToList();

            double currentAmountOfMoney = 100000, numberOfShares = 0;
            foreach (var weeklyValue in stockData)
            {
                if (weeklyValue.DerivativeDifference > 0)
                {
                    numberOfShares += currentAmountOfMoney / weeklyValue.Price;
                    currentAmountOfMoney = 0;
                }
                else
                {
                    currentAmountOfMoney += numberOfShares * weeklyValue.Price;
                    numberOfShares = 0;
                }
            }

            var finalAmountOfMoney = currentAmountOfMoney + numberOfShares * stockData.Last().Price;

            Console.WriteLine($"Read {stockData.Count} lines");
            Console.WriteLine($"You earned {finalAmountOfMoney}");
        }
    }
}
