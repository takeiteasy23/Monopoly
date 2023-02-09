using Application.Common;
using Domain;

namespace Server.Repositories;

public class InMemoryRepository : IRepository
{
    private static readonly Dictionary<string, Game> Games = new();

    public Game FindGameById(string id)
    {
        Games.TryGetValue(id, out Game? game);
        return game;
    }

    public string Save(Game game)
    {
        if (game.Id == null)
        {
            game.Id = (Games.Count + 1).ToString();
        }
        Games[game.Id] = game;
        return game.Id;
    }
}