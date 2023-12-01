using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
                Console.WriteLine("7. Выход");

                Console.Write("Выберите действие (1-5): ");
                string choice = Console.ReadLine();

                using (GameContext db = new GameContext())
                {
                    switch (choice)
                    {
                        case "1":
                            AddStyle(db);
                            break;
                        case "2":
                            AddStudio(db);
                            break;
                        case "3":
                            AddGame(db);
                            break;
                        case "4":
                            PrintAll(db);
                            break;
                        case "5":
                            PrintStudios(db);
                            break;
                        case "6":
                            PrintStyles(db);
                            break;
                        case "7":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите от 1 до 7.");
                            break;
                    }
                }
            }
        }

        public static void AddStyle(GameContext db)
        {
            Console.Write("Введите название стиля: ");
            string styleName = Console.ReadLine();

            var newStyle = new Style { Name = styleName };
            db.Style.Add(newStyle);
            db.SaveChanges();

            Console.WriteLine("Стиль успешно добавлен.");
        }

        public static void AddStudio(GameContext db)
        {
            Console.Write("Введите название студии: ");
            string studioName = Console.ReadLine();

            var newStudio = new Studio { Name = studioName };
            db.Studio.Add(newStudio);
            db.SaveChanges();

            Console.WriteLine("Студия успешно добавлена.");
        }

public static void AddGame(GameContext db)
{
    Console.Write("Введите название игры: ");
    string gameName = Console.ReadLine();

    Console.Write("Введите Id студии: ");
    if (!int.TryParse(Console.ReadLine(), out int idStudio))
    {
        Console.WriteLine("Некорректный ввод для Id студии.");
        return;
    }

    Console.Write("Введите Id стиля: ");
    if (!int.TryParse(Console.ReadLine(), out int idStyle))
    {
        Console.WriteLine("Некорректный ввод для Id стиля.");
        return;
    }

    Console.Write("Введите дату игры (гггг-мм-дд): ");
    if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly date))
    {
        Console.WriteLine("Некорректный ввод для даты игры.");
        return;
    }

    Console.Write("Введите режим игры однопользовательский - Single, Многопользовательский - Command: ");
    string gamemode = Console.ReadLine();

    Console.Write("Введите количество проданых копий: ");
    if (!int.TryParse(Console.ReadLine(), out int copiessold))
    {
        Console.WriteLine("Некорректный ввод для количество проданых копий.");
        return;
    }

            var newGame = new Game
    {
        Name = gameName,
        IdStudio = idStudio,
        IdStyle = idStyle,
        Date = date,
        GameMode = gamemode,
        CopiesSold = copiessold,
        };

    db.Game.Add(newGame);
    db.SaveChanges();

    Console.WriteLine("Игра успешно добавлена.");
}
        public static void PrintAll(GameContext db)
        {
            try
            {
                var styles = db.Style.ToList();
                var studios = db.Studio.ToList();
                var games = db.Game.ToList();

                var query = from game in games
                            join studio in studios on game.IdStudio equals studio.Id
                            join style in styles on game.IdStyle equals style.Id
                            select new
                            {
                                IdGame = game.Id,
                                GameName = game.Name,
                                IdStudio = game.IdStudio,
                                StudioName = studio.Name,
                                IdStyle = game.IdStyle,
                                StyleGame = style.Name,
                                DataGame = game.Date,
                                GameMode=game.GameMode,
                                CopiesSold=game.CopiesSold
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"IdGame: {item.IdGame}, GameName: {item.GameName}, IdStudio: {item.IdStudio},StudioName: {item.StudioName}, IdStyle: {item.IdStyle}, StyleGame: {item.StyleGame}, DateGame: {item.DataGame}, GameMode: {item.GameMode}, CopiesSold: {item.CopiesSold}");
                }
                }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintStudios(GameContext db)
        {
            try
            {
                var studios = db.Studio.ToList();

                var query = from studio in studios
                            select new
                            {
                                IdStudio = studio.Id,
                                StudioName = studio.Name,
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"IdStudios: {item.IdStudio}, StudioName: {item.StudioName}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void PrintStyles(GameContext db)
        {
            try
            {
                var styles = db.Style.ToList();

                var query = from style in styles
                            select new
                            {
                                IdStule = style.Id,
                                Style = style.Name,
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"IdStule: {item.IdStule}, Style: {item.Style}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
