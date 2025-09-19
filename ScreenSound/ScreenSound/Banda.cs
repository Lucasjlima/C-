namespace ScreenSound;

public class Banda(string nome)
{
    private List<Album> albums = new List<Album>();

    public string Nome { get; } = nome;

    public void AdicionarAlbum(Album album)
    {
        albums.Add(album);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Exibindo Discografia da banda: {Nome}");
        foreach (var album in albums)
        {
            Console.WriteLine($"Álbum: {album.Nome} (Duração total: {album.DuracaoTotal})");
        }
    }
}