using Microsoft.AspNetCore.Mvc;
using MovieManager.Models.DTO;
using MovieManager.Models.Entities;
using MovieManager.Services.MovieServices;
using System.Threading.Tasks;

namespace MovieManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpPost("add-movie")]
        public IActionResult Post([FromBody] MovieRequest request)
        {
            return Ok(_movieService.AddMovie(request));
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
            return await _movieService.GetMovies();
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            return Ok(_movieService.GetMovie(id));
        }

        [HttpPut("update-movie")]
        public IActionResult Put(int movieId, [FromBody] UpdateMovieRequest request)
        {
            return Ok(_movieService.UpdateMovieInfo(movieId, request));
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
           _movieService.RemoveMovie(id);
        }

    }
}
