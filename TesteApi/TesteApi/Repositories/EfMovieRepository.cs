using TesteApi.DTOS;
using TesteApi.Entities;
using TesteApi.Infrastructure;

namespace TesteApi.Repositories
{
    public class EfMovieRepository : IMovieRepository
    {

        private readonly AppDbContext _context;

        public EfMovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAll() => _context.Movies.ToList();

        public Movie? GetById(int id) => _context.Movies.Find(id);

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}
