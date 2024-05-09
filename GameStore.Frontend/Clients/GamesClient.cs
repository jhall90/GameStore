using GameStore.Frontend.Models;
using Microsoft.Extensions.ObjectPool;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    //// pre API backend
    // private readonly List<GameSummary> games =
    // [
    //     new (){
    //         Id = 1,
    //         Name = "World of Warcraft",
    //         Genre = "MMORPG",
    //         Price = 50.00M,
    //         ReleaseDate = new DateOnly(2004, 11, 14)
    //     },
    //     new (){
    //         Id = 2,
    //         Name = "Final Fantasy XIV",
    //         Genre = "RPG",
    //         Price = 59.99M,
    //         ReleaseDate = new DateOnly(2010, 9, 30)
    //     },
    //     new (){
    //         Id = 3,
    //         Name = "FIFA 23",
    //         Genre = "Sports",
    //         Price = 69.99M,a
    //         ReleaseDate = new DateOnly(2022, 9, 27)
    //     }
    // ];

    //// pre API backend
    // private readonly Genre[] genres = new GenresClient(httpClient).GetGenres();

    ///////////////////
    ///
    ///  Public Methods
    ///
    ///////////////////
    // all the void methods are swapped to async Task with api
    public async Task<GameSummary[]> GetGamesAsync()
        => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
    //// pre API backend    
    //[.. games]; 


    public async Task AddGameAsync(GameDetails game)
        => await httpClient.PostAsJsonAsync("games", game);
    //// pre API backend
    // {
    //     Genre genre = GetGenreById(game.GenreId);

    //     var gameSummary = new GameSummary
    //     {
    //         Id = games.Count + 1,
    //         Name = game.Name,
    //         Genre = genre.Name,
    //         Price = game.Price,
    //         ReleaseDate = game.ReleaseDate
    //     };

    //     games.Add(gameSummary);
    // }

    public async Task<GameDetails> GetGameAsync(int id)
        => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}")
            ?? throw new Exception("Game could not be found");
    //// pre API backend
    // {
    //     GameSummary game = GetGameSummaryById(id);

    //     // string.Equals(___,___, StringComparison.OrdinalIgnoreCase) 
    //     // ignores case sensitivity instead of having to convert the case manually first
    //     // .Single is a simple array
    //     // can use .First or .FirstOrDefault
    //     var genre = genres.Single(genre => string.Equals(
    //         genre.Name,
    //         game.Genre,
    //         StringComparison.OrdinalIgnoreCase)
    //     );

    //     return new GameDetails
    //     {
    //         Id = game.Id,
    //         Name = game.Name,
    //         GenreId = genre.Id.ToString(),
    //         Price = game.Price,
    //         ReleaseDate = game.ReleaseDate
    //     };
    // }
    public async Task UpdateGameAsync(GameDetails updatedGame)
        => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
    //// pre API backend
    // {
    //     var genre = GetGenreById(updatedGame.GenreId);
    //     GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

    //     existingGame.Name = updatedGame.Name;
    //     existingGame.Genre = genre.Name;
    //     existingGame.Price = updatedGame.Price;
    //     existingGame.ReleaseDate = updatedGame.ReleaseDate;
    // }

    public async Task DeleteGameAsync(int id)
        => await httpClient.DeleteAsync($"games/{id}");
    //// pre API backend
    // {
    //     var game = GetGameSummaryById(id);
    //     games.Remove(game);
    // }

    //// pre API backend
    // ///////////////////
    // ///
    // ///  Helper Methods
    // ///
    // ///////////////////
    // private Genre GetGenreById(string? id)
    // {
    //     ArgumentException.ThrowIfNullOrWhiteSpace(id);
    //     var genre = genres.Single(genre => genre.Id == int.Parse(id));
    //     return genre;
    // }
    // private GameSummary GetGameSummaryById(int id)
    // {
    //     // .Find because it is a list
    //     // Instead of var game we change it to the explicit type and see that it is nullable
    //     GameSummary? game = games.Find(game => game.Id == id);
    //     ArgumentNullException.ThrowIfNull(game);
    //     return game;
    // }
}
