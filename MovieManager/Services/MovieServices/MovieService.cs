using AutoMapper;
using MovieManager.Data.Interface;
using MovieManager.Models.DTO;
using MovieManager.Models.Entities;
using MovieManager.Services.ServiceFactory;

namespace MovieManager.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Movie> _moviesRepo;
        private readonly IServiceFactory _serviceFactory;
        private readonly IMapper _mapper;



        public MovieService(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _unitOfWork = _serviceFactory.GetService<IUnitOfWork>();
            _moviesRepo = _unitOfWork.GetRepository<Movie>();
            _mapper = _serviceFactory.GetService<IMapper>();

        }

        public async Task<string> AddMovie(MovieRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var newMovie = new Movie();
            newMovie = _mapper.Map(request, newMovie);

            await _moviesRepo.AddAsync(newMovie);
            return "Movie added successfully!";
        }

        public async Task<Movie> GetMovie(int id)
        {
            var movie = await _moviesRepo.GetByIdAsync(id) ?? throw new KeyNotFoundException("Invalid movie id");

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _moviesRepo.GetAllAsync();
        }

        public void RemoveMovie(int id)
        {
            _moviesRepo.DeleteById(id);
        }

        public async Task<string> UpdateMovieInfo(int movieId, UpdateMovieRequest request)
        {
            var movie = await _moviesRepo.GetByIdAsync(movieId) ?? throw new KeyNotFoundException("Invalid movie id");
            movie = _mapper.Map(request, movie);

            await _moviesRepo.UpdateAsync(movie);

            return "Update successful";
        }
    }
}
