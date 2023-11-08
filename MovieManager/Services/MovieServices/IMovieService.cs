using MovieManager.Models.DTO;
using MovieManager.Models.Entities;

namespace MovieManager.Services.MovieServices
{
    public interface IMovieService
    {
        public Task<string> AddMovie(MovieRequest request);
        public void RemoveMovie(int id);
        public Task<string> UpdateMovieInfo(int movieId, UpdateMovieRequest request);
        public Task<IEnumerable<Movie>> GetMovies();
        public Task<Movie> GetMovie(int id);
    }
}
