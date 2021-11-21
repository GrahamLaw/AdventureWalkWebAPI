using AdventureWalk.Data;
using AdventureWalk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdventureWalk.Controllers
{
    [Route("player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerRepository playerRepository;

        public PlayerController(PlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        [HttpGet]
        // [Route("api/Player/Get")]
        public List<Player> Get()
        {
            //using (QuizDBContext db = new QuizDBContext())
            //{
            //    var players = db.Players.ToList();                
            //    return players;
            //}

            try
            {
                var result = playerRepository.GetPlayers();
                return result;
            }
            catch 
            { 
            
            }

            return null;
        }

        [HttpGet("GetAsync")]        
        public async Task<ActionResult<List<Player>>> GetAsync()
        {
            try
            {
                var result = await playerRepository.GetPlayersAsync();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<Player2Controller>
        [HttpPost]
        [Route("api/InsertPlayer")]
        public Player Insert(Player model)
        {
            using (QuizDBContext db = new QuizDBContext())
            {
                db.Players.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        
        [HttpPost]
        [Route("api/UpdateOutput")]
        public void UpdateOutput(Player model)
        {
            using (QuizDBContext db = new QuizDBContext())
            {
                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();                
            }
        }
    }
}
