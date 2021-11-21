using AdventureWalk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdventureWalk.Data
{
    public class PlayerRepository
    {
        private readonly QuizDBContext dbContext;

        public PlayerRepository(QuizDBContext dbContext)
        {
            this.dbContext = dbContext;        
        }

        public List<Player> GetPlayers() 
        {            
            var players = dbContext.Players.ToList();
            return players;            
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            var players = await dbContext.Players.ToListAsync();

            return players;

            var query = from player in dbContext.Players
                        select player;

            return await query.ToListAsync();
        }
    }
}
