using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
    private readonly Genre[] genres = 
    [
        new () {
            Id = 1,
            Name = "Fighting"
        },
        new () {
            Id = 2,
            Name = "MMORPG"
        },
        new () {
            Id = 3,
            Name = "RPG"
        },
        new () {
            Id = 4,
            Name = "Sports"
        },
        new () {
            Id = 5,
            Name = "Racing"
        },
        new () {
            Id = 6,
            Name = "Kids and Family"
        }
    ];

    public Genre[] GetGenres() => genres;
}
