using System;
using System.Linq;

namespace ConsoleApp2
{
    public static class Linq
    {
        //Завдання 1
        //Показать Топ-3 студии с максимальным количеством игр.
        public static void DisplayTop3StudiosWithMostGames(GameContext db)
        {
            var top3StudiosWithGamesCount = db.Studio
                .Select(studio => new
                {
                    Studio = studio,
                    GamesCount = db.Game.Count(game => game.IdStudio == studio.Id)
                })
                .OrderByDescending(x => x.GamesCount)
                .Take(3)
                .ToList();

            if (top3StudiosWithGamesCount.Any())
            {
                Console.WriteLine("Топ-3 студии с максимальным количеством игр:");

                foreach (var result in top3StudiosWithGamesCount)
                {
                    Console.WriteLine($"Студия: {result.Studio.Name}, Количество игр: {result.GamesCount}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных о студиях.");
            }
        }

        //отображение студии с максимальным количеством игр

        public static void DisplayStudioWithMostGames(GameContext db)
        {
            var studioWithMostGames = db.Studio
                .Select(studio => new
                {
                    Studio = studio,
                    GamesCount = db.Game.Count(game => game.IdStudio == studio.Id)
                })
                .OrderByDescending(x => x.GamesCount)
                .FirstOrDefault();

            if (studioWithMostGames != null)
            {
                Console.WriteLine($"Студия с максимальным количеством игр: {studioWithMostGames.Studio.Name}");
                Console.WriteLine($"Количество игр: {studioWithMostGames.GamesCount}");
            }
            else
            {
                Console.WriteLine("Нет данных о студиях.");
            }
        }

        //отображение самого популярного стиля по количеству игр
        public static void DisplayMostPopularStyle(GameContext db)
        {
            var mostPopularStyle = db.Style
                .Select(style => new
                {
                    Style = style,
                    GamesCount = db.Game.Count(game => game.IdStyle == style.Id)
                })
                .OrderByDescending(x => x.GamesCount)
                .FirstOrDefault();

            if (mostPopularStyle != null)
            {
                Console.WriteLine($"Самый популярный стиль: {mostPopularStyle.Style.Name}");
                Console.WriteLine($"Количество игр: {mostPopularStyle.GamesCount}");
            }
            else
            {
                Console.WriteLine("Нет данных о стилях игр.");
            }
        }

        //Завдання 2
        //Показать Топ-3 самые популярные стили по количеству продаж
        public static void DisplayTop3PopularStylesBySales(GameContext db)
        {
            var top3Styles = db.Style
                .ToList(); // Загружаем все стили из базы данных

            if (top3Styles.Any())
            {
                Console.WriteLine("Топ-3 самых популярных стилей по количеству продаж:");

                var top3StylesBySales = top3Styles
                    .Select(style => new
                    {
                        Style = style,
                        TotalSales = db.Game.Where(game => game.IdStyle == style.Id).Sum(game => game.CopiesSold)
                    })
                    .OrderByDescending(x => x.TotalSales)
                    .Take(3)
                    .ToList();

                foreach (var result in top3StylesBySales)
                {
                    Console.WriteLine($"Стиль: {result.Style.Name}, Общее количество продаж: {result.TotalSales}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных о стилях игр.");
            }
        }

        //Топ-3 самых популярных однопользовательских игр по количеству продаж
        public static void DisplayTop3SinglePlayerGamesBySales(GameContext db)
        {
            var top3SinglePlayerGames = db.Game
                .Where(game => game.GameMode == "Single") 
                .OrderByDescending(game => game.CopiesSold)
                .Take(3)
                .ToList();

            if (top3SinglePlayerGames.Any())
            {
                Console.WriteLine("Топ-3 самых популярных однопользовательских игр по количеству продаж:");

                foreach (var game in top3SinglePlayerGames)
                {
                    Console.WriteLine($"Игра: {game.Name}, Количество продаж: {game.CopiesSold}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных о однопользовательских играх.");
            }
        }

        //Топ-3 самых популярных многопользовательских игр по количеству продаж
        public static void DisplayTop3MultiPlayerGamesBySales(GameContext db)
        {
            var top3SinglePlayerGames = db.Game
                .Where(game => game.GameMode == "Command")
                .OrderByDescending(game => game.CopiesSold)
                .Take(3)
                .ToList();

            if (top3SinglePlayerGames.Any())
            {
                Console.WriteLine("Топ-3 самых популярных однопользовательских игр по количеству продаж:");

                foreach (var game in top3SinglePlayerGames)
                {
                    Console.WriteLine($"Игра: {game.Name}, Количество продаж: {game.CopiesSold}");
                }
            }
            else
            {
                Console.WriteLine("Нет данных о однопользовательских играх.");
            }
        }

        //Показать самую популярную однопользовательскую игру по количеству продаж
        public static void DisplayMostPopularSinglePlayerGameBySales(GameContext db)
        {
            var mostPopularSinglePlayerGame = db.Game
                .Where(game => game.GameMode == "Single") // Выбираем только однопользовательские игры
                .OrderByDescending(game => game.CopiesSold)
                .FirstOrDefault();

            if (mostPopularSinglePlayerGame != null)
            {
                Console.WriteLine($"Самая популярная однопользовательская игра по количеству продаж: {mostPopularSinglePlayerGame.Name}");
            }
            else
            {
                Console.WriteLine("Нет данных о однопользовательских играх.");
            }
        }

        //Показать самую популярную многопользовательскую игру по количеству продаж
        public static void DisplayMostPopularMultiplayerGameBySales(GameContext db)
        {
            var mostPopularMultiplayerGame = db.Game
                .Where(game => game.GameMode == "Command") // Выбираем только многопользовательские игры
                .OrderByDescending(game => game.CopiesSold)
                .FirstOrDefault();

            if (mostPopularMultiplayerGame != null)
            {
                Console.WriteLine($"Самая популярная многопользовательская игра по количеству продаж: {mostPopularMultiplayerGame.Name}");
            }
            else
            {
                Console.WriteLine("Нет данных о многопользовательских играх.");
            }
        }

        // Показать самую популярную игру по количеству продаж.
        public static void DisplayMostPopularGameBySales(GameContext db)
        {
            var mostPopularGame = db.Game
                .OrderByDescending(game => game.CopiesSold)
                .FirstOrDefault();

            if (mostPopularGame != null)
            {
                Console.WriteLine($"Самая популярная игра по количеству продаж: {mostPopularGame.Name}");
            }
            else
            {
                Console.WriteLine("Нет данных о продажах игр.");
            }
        }

        // Задание 3
        // удаляет все игры по количеству продажа, равных нулю
        public static void DeleteGamesWithZeroSales(GameContext db)
        {
            var gamesWithZeroSales = db.Game.Where(game => game.CopiesSold == 0).ToList();

            if (gamesWithZeroSales.Any())
            {
                db.Game.RemoveRange(gamesWithZeroSales);
                db.SaveChanges();
                Console.WriteLine("Игры с нулевым количеством продаж успешно удалены.");
            }
            else
            {
                Console.WriteLine("Нет игр с нулевым количеством продаж для удаления.");
            }
        }

        //удаляет все игры по количеству продажа, равных параметру, переданному в процедуру
        public static void DeleteGamesBySales(GameContext db, int salesCount)
        {
            var gamesToDelete = db.Game.Where(game => game.CopiesSold == salesCount).ToList();

            if (gamesToDelete.Any())
            {
                db.Game.RemoveRange(gamesToDelete);
                db.SaveChanges();
                Console.WriteLine($"Игры с количеством продаж {salesCount} успешно удалены.");
            }
            else
            {
                Console.WriteLine($"Нет игр с количеством продаж {salesCount} для удаления.");
            }
        }

    }
}
