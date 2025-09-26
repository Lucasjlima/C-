using TesteApi.DTOS;
using TesteApi.Entities;
using TesteApi.DTOS;
namespace TesteApi.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}
