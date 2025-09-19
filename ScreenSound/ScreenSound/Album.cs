using ScreenSound;

public class Album(string nome, int duracaoTotal)
{
    private List<Musica> musicas = new List<Musica>();

    public string Nome { get; } = nome;
    public int DuracaoTotal => musicas.Sum(n => n.Duracao);

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void MostrarAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum: {Nome}\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }

        Console.WriteLine($"Duraçao do Album: {DuracaoTotal}");
    }
}