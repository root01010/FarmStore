using System;

namespace FarmStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Farm Store";

            const double priceGrain = 25.0;
            const double priceVegetables = 40.0;
            const double priceFruits = 35.0;
            const double priceMilk = 30.0;
            const double priceEggs = 3.0;
            const double priceHoney = 120.0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Ласкаво просимо до Farm Store ===\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Зерно  - {priceGrain} грн/кг");
            Console.WriteLine($"Овочі  - {priceVegetables} грн/кг");
            Console.WriteLine($"Фрукти - {priceFruits} грн/кг");
            Console.WriteLine($"Молоко - {priceMilk} грн/л");
            Console.WriteLine($"Яйця   - {priceEggs} грн/шт");
            Console.WriteLine($"Мед    - {priceHoney} грн/кг\n");
            Console.ResetColor();

            double grain = ReadPositiveDouble("Введіть кількість зерна (кг): ");
            double vegetables = ReadPositiveDouble("Введіть кількість овочів (кг): ");
            double fruits = ReadPositiveDouble("Введіть кількість фруктів (кг): ");
            double milk = ReadPositiveDouble("Введіть кількість молока (л): ");
            double eggs = ReadPositiveDouble("Введіть кількість яєць (шт): ");
            double honey = ReadPositiveDouble("Введіть кількість меду (кг): ");

            double totalGrain = grain * priceGrain;
            double totalVegetables = vegetables * priceVegetables;
            double totalFruits = fruits * priceFruits;
            double totalMilk = milk * priceMilk;
            double totalEggs = eggs * priceEggs;
            double totalHoney = honey * priceHoney;

            double totalPrice = totalGrain + totalVegetables + totalFruits + totalMilk + totalEggs + totalHoney;

            Random random = new Random();
            double randomDiscount = random.NextDouble() * 10.0; // випадкова знижка від 0 до 10%
            double discountTotal = totalPrice - totalPrice * randomDiscount / 100.0;

            // Додаткове використання Math.Pow та Math.Sqrt для демонстрації Math у програмі
            double bonusIndex = Math.Sqrt(Math.Pow(totalPrice, 2));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Деталі покупки ===");
            Console.ResetColor();

            PrintLine("Зерно", totalGrain);
            PrintLine("Овочі", totalVegetables);
            PrintLine("Фрукти", totalFruits);
            PrintLine("Молоко", totalMilk);
            PrintLine("Яйця", totalEggs);
            PrintLine("Мед", totalHoney);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nЗагальна сума: {Math.Round(totalPrice, 2):F2} грн");
            Console.WriteLine($"Знижка: {Math.Round(randomDiscount, 2):F2}%");
            Console.WriteLine($"Сума зі знижкою: {Math.Round(discountTotal, 2):F2} грн");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Перевірочний індекс Math.Sqrt(Math.Pow(totalPrice, 2)): {Math.Round(bonusIndex, 2):F2}");
            Console.ResetColor();

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        static double ReadPositiveDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                try
                {
                    double value = Convert.ToDouble(input);
                    if (value >= 0)
                    {
                        return value;
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: число не може бути від'ємним.");
                    Console.ResetColor();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: введіть коректне число.");
                    Console.ResetColor();
                }
            }
        }

        static void PrintLine(string productName, double total)
        {
            Console.WriteLine($"{productName,-8}: {Math.Round(total, 2):F2} грн");
        }
    }
}
