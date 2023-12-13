using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить стиль");
                Console.WriteLine("2. Добавить студию");
                Console.WriteLine("3. Добавить игру");
                Console.WriteLine("4. Вывести все данные");
                Console.WriteLine("5. Вывести все студии");
                Console.WriteLine("6. Вывести все стили");
                Console.WriteLine("7. Отображение количества однопользовательских и многопользовательских игр");
                Console.WriteLine("8. Показать игру с максимальным количеством проданных копий определенного стиля");
                Console.WriteLine("9. Отобразить Топ-5 игр по наибольшему количеству продаж определенного стиля");
                Console.WriteLine("10. Отобразить Топ-5 игр по наименьшему количеству продаж определенного стиля");
                Console.WriteLine("11. Отобразить полную информацию об игре");
                Console.WriteLine("12. Отобразить название каждой студии и стиль игр, количество которых преобладает");
                Console.WriteLine("13. Выход");

                Console.Write("Выберите действие (1-13): ");
                string choice = Console.ReadLine();

                using (GameContext db = new GameContext())
                {
                    switch (choice)
                    {
                        case "1":
                            GameService.AddStyle(db);
                            break;
                        case "2":
                            GameService.AddNewStudio(db);
                            break;
                        case "3":
                            GameService.AddGame(db);
                            break;
                        case "4":
                            GameService.PrintAll(db);
                            break;
                        case "5":
                            GameService.PrintStudios(db);
                            break;
                        case "6":
                            GameService.PrintStyles(db);
                            break;
                        case "7":
                            GameService.DisplayGameModesCount(db);
                            break;
                        case "8":
                            Console.Write("Введите название стиля: ");
                            string styleName8 = Console.ReadLine();
                            GameService.DisplayMaxSoldGameByStyle(db, styleName8);
                            break;
                        case "9":
                            Console.Write("Введите название стиля: ");
                            string styleName9 = Console.ReadLine();
                            GameService.DisplayTop5GamesBySales(db, styleName9, true);
                            break;
                        case "10":
                            Console.Write("Введите название стиля: ");
                            string styleName10 = Console.ReadLine();
                            GameService.DisplayTop5GamesBySales(db, styleName10, false);
                            break;
                        case "11":
                            Console.Write("Введите Id игры: ");
                            if (int.TryParse(Console.ReadLine(), out int gameId11))
                            {
                                GameService.DisplayGameInfo(db, gameId11);
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод для Id игры.");
                            }
                            break;
                        case "12":

                            GameService.DisplayStudioMaxGameByStyle(db);
                            break;
                        case "13":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите от 1 до 13.");
                            break;
                    }
                }
            }
        }
    }
}
