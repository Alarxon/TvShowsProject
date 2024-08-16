using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvShowsProject.Server.Models;

namespace TvShowsProject.Server.Controllers
{
    /// <summary>
    /// TvShow API REST
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        private readonly TvShowContext _context;

        /// <summary>
        /// Class contructor
        /// </summary>
        /// <param name="context">The DbContext for the TvShow Model</param>
        /// <returns>None</returns>
        public TvShowsController(TvShowContext context)
        {
            _context = context;
        }

        // GET: api/TvShows
        /// <summary>
        /// Gets all TV Shows, order by Id
        /// </summary>
        /// <param>None</param>
        /// <returns>A JSON with all the TV Shows and their atributes (Id, Name and Favorite)</returns>
        /// <response code="200">All available TVShows returned correctly</response>        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TvShow>>> GetTvShowItems()
        {
            return await _context.TvShowItems.OrderBy(i => i.Id).ToListAsync();
        }

        // GET: api/TvShows/5
        /// <summary>
        /// Gets an specific TV Show by Id
        /// </summary>
        /// <param name="id">The TV Show unique Id (integer)</param>
        /// <returns>A JSON with the specific TV Show (Code 200) or NotFound (Code 404) if their isn't one with a matching Id</returns>
        /// <response code="200">TvShow returned correctly</response> 
        /// <response code="404">Not Matching Id for TVShow</response>  
        [HttpGet("{id}")]
        public async Task<ActionResult<TvShow>> GetTvShow(int id)
        {
            var tvShow = await _context.TvShowItems.FindAsync(id);

            if (tvShow == null)
            {
                return NotFound();
            }

            return tvShow;
        }

        // GET: api/TvShows/getFavorites/true
        /// <summary>
        /// Gets all the TV Shows by their Favorite value (Either all the favorites or all the Non favorites)
        /// </summary>
        /// <param name="favorite">The type of Favorite (true or false)</param>
        /// <returns>A JSON with all the specifics TV Shows (Code 200)</returns>
        /// <response code="200">All matching TvShows returned correctly</response> 
        [HttpGet("getFavorites/{favorite}")]
        public async Task<ActionResult<IEnumerable<TvShow>>> GetTvShowFavorites(bool favorite)
        {
            return await _context.TvShowItems.Where(x => x.Favorite == favorite).ToListAsync();
        }

        // PUT: api/TvShows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific TvShow by Id
        /// </summary>
        /// <param name="id">The id of the specific TvShow to update (Integer)</param>
        /// <param name="tvShow">The TvShow object with the new data to update (Formated Json)</param>
        /// <returns>NoContent if the update was correct (Code 204), NotFound (Code 404) if there isn't a matching Id, or BadRequest (400 Code) if the parameter Id is not the same as the Id in the TvShow JSON</returns>
        /// <response code="204">TvShow updated correctly</response> 
        /// <response code="404">Not Matching Id for TvShow</response> 
        /// <response code="400">Parameter Id not equal to JSON Id</response> 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTvShow(int id, TvShow tvShow)
        {
            if (id != tvShow.Id)
            {
                return BadRequest();
            }

            _context.Entry(tvShow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TvShowExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TvShows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Inserts a specific TvShow
        /// </summary>
        /// <param name="tvShow">The TvShow object with the new data to insert (Formated Json)</param>
        /// <returns>A CreatedAtAction (201 Code if correct or a 400 code if incorrect)</returns>
        /// <response code="201">TvShow created correctly</response>
        /// <response code="400">TvShow not created correctly, bad JSON format</response> 
        [HttpPost]
        public async Task<ActionResult<TvShow>> PostTvShow(TvShow tvShow)
        {
            _context.TvShowItems.Add(tvShow);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTvShow", new { id = tvShow.Id }, tvShow);
            //nameof keyword is used to avoid hard-coding the action name 
            return CreatedAtAction(nameof(GetTvShow), new { id = tvShow.Id }, tvShow);
        }

        // DELETE: api/TvShows/5
        /// <summary>
        /// Deletes a specific Tv Show by Id
        /// </summary>
        /// <param name="id">The Id of the specific TvShow to delete (Integer)</param>
        /// <returns>NoContent if the update was correct (Code 204), NotFound (Code 404) if there isn't a matching Id</returns>
        /// <response code="204">TvShow deleted correctly</response>
        /// <response code="404">Not Matching Id for TvShow</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTvShow(int id)
        {
            var tvShow = await _context.TvShowItems.FindAsync(id);
            if (tvShow == null)
            {
                return NotFound();
            }

            _context.TvShowItems.Remove(tvShow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Internal private function, it is used to know if a Tv Show already exists
        private bool TvShowExists(int id)
        {
            return _context.TvShowItems.Any(e => e.Id == id);
        }
    }
}
