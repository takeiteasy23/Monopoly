using Application.Common;
using Domain;

namespace ApplicationTests;

public class Utils
{
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
            Games[game.Id] = game;
            return game.Id;
        }
    }
}