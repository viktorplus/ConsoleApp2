using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace ConsoleApp2
{
    public static  class GameService
    {
        public static void AddStyle(GameContext db)
        {
            Console.Write("Введите название стиля: ");
            string styleName = Console.ReadLine();

            var newStyle = new Style { Name = styleName };
            db.Style.Add(newStyle);
            db.SaveChanges();

            Console.WriteLine("Стиль успешно добавлен.");
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
                                Country = studio.Country,
                                City = studio.City,
                                IdStyle = game.IdStyle,
                                StyleGame = style.Name,
                                DataGame = game.Date,
                                GameMode = game.GameMode,
                                CopiesSold = game.CopiesSold
                            };

                foreach (var item in query)
                {
                    Console.WriteLine($"IdGame: {item.IdGame}, GameName: {item.GameName}, IdStudio: {item.IdStudio}, StudioName: {item.StudioName}, Country: {item.Country}, City: {item.City}, IdStyle: {item.IdStyle}, StyleGame: {item.StyleGame}, DateGame: {item.DataGame}, GameMode: {item.GameMode}, CopiesSold: {item.CopiesSold}");
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
        public static void AddNewStudio(GameContext db)
        {
            Console.Write("Введите название новой студии: ");
            string studioName = Console.ReadLine();

            // Проверка наличия студии
            if (db.Studio.Any(s => s.Name == studioName))
            {
                Console.WriteLine("Студия с таким названием уже существует.");
                return;
            }

            Console.Write("Введите страну: ");
            string country = Console.ReadLine();

            Console.Write("Введите город: ");
            string city = Console.ReadLine();

            var newStudio = new Studio { Name = studioName, Country = country, City = city };
            db.Studio.Add(newStudio);
            db.SaveChanges();

            Console.WriteLine("Новая студия успешно добавлена.");
        }
        public static void UpdateStudio(GameContext db)
        {
            Console.Write("Введите название студии, данные которой вы хотите изменить: ");
            string studioName = Console.ReadLine();

            var studioToUpdate = db.Studio.FirstOrDefault(s => s.Name == studioName);

            if (studioToUpdate != null)
            {
                Console.Write("Введите новое название студии: ");
                studioToUpdate.Name = Console.ReadLine();

                Console.Write("Введите новую страну: ");
                studioToUpdate.Country = Console.ReadLine();

                Console.Write("Введите новый город: ");
                studioToUpdate.City = Console.ReadLine();

                db.SaveChanges();

                Console.WriteLine("Данные студии успешно обновлены.");
            }
            else
            {
                Console.WriteLine($"Студия с названием {studioName} не найдена.");
            }
        }

        public static void DeleteStudio(GameContext db)
        {
            Console.Write("Введите название студии, которую вы хотите удалить: ");
            string studioName = Console.ReadLine();

            var studioToDelete = db.Studio.FirstOrDefault(s => s.Name == studioName);

            if (studioToDelete != null)
            {
                Console.Write($"Вы уверены, что хотите удалить студию {studioName}? (Y/N): ");
                string confirmation = Console.ReadLine();

        if (confirmation.ToUpper() == "Y")
        {
            // Удаляем студию
            db.Studio.Remove(studioToDelete);
            db.SaveChanges();
            Console.WriteLine($"Студия {studioName} успешно удалена.");
        }
        else
        {
            Console.WriteLine($"Удаление студии {studioName} отменено.");
        }
            }
                else
            {
                Console.WriteLine($"Студия с названием {studioName} не найдена.");
            }
        }


        public static void PrintStudios(GameContext db)
        {
            try
            {
                var studios = db.Studio.ToList();

                foreach (var studio in studios)
                {
                    Console.WriteLine($"IdStudios: {studio.Id}, StudioName: {studio.Name}, Country: {studio.Country}, City: {studio.City}");
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
        // Новое задание /// Новые методы
        //Отображение количества однопользовательских и многопользовательских игр:

        public static void DisplayGameModesCount(GameContext db)
        {
            var singlePlayerCount = db.Game.Count(g => g.GameMode == "Single");
            var multiplayerCount = db.Game.Count(g => g.GameMode == "Multiplayer");

            Console.WriteLine($"Количество однопользовательских игр: {singlePlayerCount}");
            Console.WriteLine($"Количество многопользовательских игр: {multiplayerCount}");
        }

        //Показать игру с максимальным количеством проданных копий определенного стиля:
        public static void DisplayMaxSoldGameByStyle(GameContext db, string styleName)
        {
            var maxSoldGame = (from game in db.Game
                               join style in db.Style on game.IdStyle equals style.Id
                               where style.Name == styleName
                               orderby game.CopiesSold descending
                               select game)
                              .FirstOrDefault();

            if (maxSoldGame != null)
            {
                Console.WriteLine($"Игра с максимальным количеством проданных копий стиля '{styleName}':");
                maxSoldGame.Print();
            }
            else
            {
                Console.WriteLine($"Нет игр в стиле '{styleName}'.");
            }
        }

        //Отображение Топ-5 игр по наибольшему и наименьшему количеству продаж определенного стиля:

        public static void DisplayTop5GamesBySales(GameContext db, string styleName, bool ascending = false)
        {
            var query = db.Game.Join(db.Style,
                            game => game.IdStyle,
                            style => style.Id,
                            (game, style) => new { Game = game, Style = style })
                        .Where(joined => joined.Style.Name == styleName)
                        .OrderBy(joined => ascending ? joined.Game.CopiesSold : -joined.Game.CopiesSold)
                        .Take(5)
                        .Select(joined => joined.Game);

            Console.WriteLine($"Топ-5 игр по {(ascending ? "наименьшему" : "наибольшему")} количеству продаж стиля '{styleName}':");

            foreach (var game in query)
            {
                game.Print();
            }
        }

        //Отобразить полную информацию об игре:
        public static void DisplayGameInfo(GameContext db, int gameId)
        {
            var game = db.Game.FirstOrDefault(g => g.Id == gameId);

            if (game != null)
            {
                Console.WriteLine("Полная информация об игре:");
                game.Print();
            }
            else
            {
                Console.WriteLine($"Игра с Id {gameId} не найдена.");
            }
        }

        //Отобразить название каждой студии и стиль игр, количество которых преобладает:
        public static void DisplayStudioMaxGameByStyle(GameContext db)
        {
            var studios = db.Studio.ToList();

            Console.WriteLine("Название студии и стиль игры, количество которых преобладает:");

            foreach (var studio in studios)
            {
                var dominantStyle = db.Game
                    .Where(g => g.IdStudio == studio.Id)
                    .GroupBy(g => g.IdStyle)
                    .AsEnumerable() // Выгружаем данные на клиентскую сторону
                    .OrderByDescending(group => group.Count())
                    .FirstOrDefault()?
                    .FirstOrDefault();

                if (dominantStyle != null)
                {
                    var styleName = db.Style
                        .Where(s => s.Id == dominantStyle.IdStyle)
                        .Select(s => s.Name)
                        .FirstOrDefault();

                    Console.WriteLine($"Студия: {studio.Name}, Преобладающий стиль: {styleName ?? "нет данных"}");
                }
                else
                {
                    Console.WriteLine($"Студия: {studio.Name}, Преобладающий стиль: нет данных");
                }
            }
        }

    }
}
