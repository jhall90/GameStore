using GameStore.Frontend.Models;
using Microsoft.Extensions.ObjectPool;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = 
    [
        new (){
            Id = 1,
            Name = "World of Warcraft",
            Genre = "MMORPG",
            Price = 50.00M,
            ReleaseDate = new DateOnly(2004, 11, 14)
        },
        new (){
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "RPG",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2010, 9, 30)
        },
        new (){
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M,
            ReleaseDate = new DateOnly(2022, 9, 27)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres(); 

///////////////////
///
///  Public Methods
///
///////////////////
    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        // string.Equals(___,___, StringComparison.OrdinalIgnoreCase) 
        // ignores case sensitivity instead of having to convert the case manually first
        // .Single is a simple array
        // can use .First or .FirstOrDefault
        var genre = genres.Single(genre => string.Equals(
            genre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase)
        );

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }

    ///////////////////
    ///
    ///  Helper Methods
    ///
    ///////////////////
    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var genre = genres.Single(genre => genre.Id == int.Parse(id));
        return genre;
    }
    private GameSummary GetGameSummaryById(int id)
    {
        // .Find because it is a list
        // Instead of var game we change it to the explicit type and see that it is nullable
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }
}
