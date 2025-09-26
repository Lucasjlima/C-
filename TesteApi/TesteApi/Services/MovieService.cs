using TesteApi.DTOS;
using TesteApi.Entities;
using TesteApi.Repositories;

namespace TesteApi.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<MovieResponseDto> GetAll()
        {
            return _repository.GetAll()
                .Select(m => new MovieResponseDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ReleaseYear = m.ReleaseYear
                });
        }

        public MovieResponseDto? GetById(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null) return null;

            return new MovieResponseDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ReleaseYear = movie.ReleaseYear
            };
        }

        public MovieResponseDto Create(MovieCreateDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Director = dto.Director,
                ReleaseYear = dto.ReleaseYear
            };

            _repository.Add(movie);

            return new MovieResponseDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ReleaseYear = movie.ReleaseYear
            };
        }

        public bool Update(int id, MovieUpdateDto dto)
        {
            var movie = _repository.GetById(id);
            if (movie == null) return false;

            movie.Title = dto.Title;
            movie.Director = dto.Director;
            movie.ReleaseYear = dto.ReleaseYear;

            _repository.Update(movie);
            return true;
        }

        public bool Delete(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null) return false;

            _repository.Delete(id);
            return true;
        }
    }
}
