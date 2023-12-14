using ConsoleApp2;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Показать Топ-3 студии с максимальным количеством игр.");
            Console.WriteLine("2. Отобразить студию с максимальным количеством игр.");
            Console.WriteLine("3. Отобразить самый популярный стиль по количеству игр.");
            Console.WriteLine("4. Показать Топ-3 самые популярные стили по количеству продаж.");
            Console.WriteLine("5. Показать Топ-3 самые популярные однопользовательские игры по количеству продаж.");
            Console.WriteLine("6. Показать Топ-3 самые популярные многопользовательские игры по количеству продаж.");
            Console.WriteLine("7. Отобразить самую популярную однопользовательскую игру по количеству продаж.");
            Console.WriteLine("8. Отобразить самую популярную многопользовательскую игру по количеству продаж.");
            Console.WriteLine("9. Отобразить самую популярную игру по количеству продаж.");
            Console.WriteLine("10. Удалить игры с нулевым количеством продаж.");
            Console.WriteLine("11. Удалить игры по количеству продаж.");
            Console.WriteLine("12. Отобразить самую популярную однопользовательскую игру по количеству продаж.");
            Console.WriteLine("13. Отобразить самую популярную многопользовательскую игру по количеству продаж.");
            Console.WriteLine("14. Отобразить самую популярную игру по количеству продаж.");
            Console.Write("Выберите действие (1-14): ");
            string choice = Console.ReadLine();

            using (GameContext db = new GameContext())
            {
                switch (choice)
                {
                    case "1":
                        Linq.DisplayTop3StudiosWithMostGames(db);
                        break;
                    case "2":
                        Linq.DisplayStudioWithMostGames(db);
                        break;
                    case "3":
                        Linq.DisplayMostPopularStyle(db);
                        break;
                    case "4":
                        Linq.DisplayTop3PopularStylesBySales(db);
                        break;
                    case "5":
                        Linq.DisplayTop3SinglePlayerGamesBySales(db);
                        break;
                    case "6":
                        Linq.DisplayTop3MultiPlayerGamesBySales(db);
                        break;
                    case "7":
                        Linq.DisplayMostPopularSinglePlayerGameBySales(db);
                        break;
                    case "8":
                        Linq.DisplayMostPopularMultiplayerGameBySales(db);
                        break;
                    case "9":
                        Linq.DisplayMostPopularGameBySales(db);
                        break;
                    case "10":
                        Linq.DeleteGamesWithZeroSales(db);
                        break;
                    case "11":
                        Console.Write("Введите количество продаж: ");
                        if (int.TryParse(Console.ReadLine(), out int salesCount))
                        {
                            Linq.DeleteGamesBySales(db, salesCount);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод для количества продаж.");
                        }
                        break;
                    case "12":
                        Linq.DisplayMostPopularSinglePlayerGameBySales(db);
                        break;
                    case "13":
                        Linq.DisplayMostPopularMultiplayerGameBySales(db);
                        break;
                    case "14":
                        Linq.DisplayMostPopularGameBySales(db);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите от 1 до 14.");
                        break;
                }
            }
        }
    }
}
