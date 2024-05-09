using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient(HttpClient httpClient)
{
    //// pre API backend
    // private readonly Genre[] genres =
    // [
    //     new () {
    //         Id = 1,
    //         Name = "Fighting"
    //     },
    //     new () {
    //         Id = 2,
    //         Name = "MMORPG"
    //     },
    //     new () {
    //         Id = 3,
    //         Name = "RPG"
    //     },
    //     new () {
    //         Id = 4,
    //         Name = "Sports"
    //     },
    //     new () {
    //         Id = 5,
    //         Name = "Racing"
    //     },
    //     new () {
    //         Id = 6,
    //         Name = "Kids and Family"
    //     }
    // ];

    public async Task<Genre[]> GetGenresAsync()
        => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? [];
    //// pre API backend
    // => genres;
}
