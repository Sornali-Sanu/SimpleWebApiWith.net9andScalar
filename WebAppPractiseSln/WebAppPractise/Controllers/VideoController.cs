using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPractise.Dal;

namespace WebAppPractise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class VideoController : ControllerBase
    {
        private readonly VideoContextDb db ;

        public VideoController(VideoContextDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<ActionResult>  GetVideoGame()
        {
            var game = await db.VideoGames.ToListAsync();
            return Ok(game);
        }
        [HttpGet("{id}")]
    
        public async Task< ActionResult> GetById(int id)
        {

            var game= await db.VideoGames.FindAsync(id);
            if (game == null)
            {
                return BadRequest("404 not found");
            }
           
                return Ok(game);
        }
        [HttpPost]
        public async Task<ActionResult> AddVideoGame(VideoGame newGame)
        {
            if (newGame == null)
            {
                return BadRequest();
            }
            db.VideoGames.Add(newGame);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id=newGame.Id},newGame);

        }
        [HttpPut("{id}")]
        public async Task <ActionResult>UpdateVideoGame(int id,VideoGame updateGame)
        {
            var game =await db.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return BadRequest("404 not found");
            }
            game.Title = updateGame.Title;
            game.Publisher = updateGame.Publisher;
            game.Developer = updateGame.Developer;
            game.Platform = updateGame.Platform;

            await db.SaveChangesAsync();
            return Ok(updateGame);



        }
        [HttpDelete("{id}")]
        public async Task <ActionResult>DeleteVideo(int id)
        {
            var game = await db.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (game == null)
            {
                return BadRequest("404 not found");
            }
            db.VideoGames.Remove(game);
            await db.SaveChangesAsync();
            return Ok("Deleted SuccessFully");
        }
    }
}
