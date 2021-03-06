using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Samir_Cabrera.Movies.Data;
using Samir_Cabrera.Movies.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samir_Cabrera.Movies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movies.Include(x => x.Images).ToListAsync();
        }

        // GET: api/Movies/ToLater
        [HttpGet("ToLater")]
        public IEnumerable<Movie> GetMovieToLater()
        {
            List<Movie> moviesToLater = _context.Movies.Where(x => x.ToViewLater == true).ToList();
            return moviesToLater;
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var movie = await _context.Movies.Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPut("changeLike/{id}")]
        public async Task<IActionResult> ChangeLike([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            movie.Like = ChangeBoolean(movie.Like);

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("changeView/{id}")]
        public async Task<IActionResult> ChangeView([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            movie.View = ChangeBoolean(movie.View);

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("changeToLater/{id}")]
        public async Task<IActionResult> ChangeToLater([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = _context.Movies.Where(x => x.Id == id).FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            movie.ToViewLater = ChangeBoolean(movie.ToViewLater);

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(Guid id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
         [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

          return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(Guid id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        private Boolean ChangeBoolean(Boolean x)
        {
            if (x == true)
            {
                return x = false;
            }

            return x = true;
        }
    }
}
