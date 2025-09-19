namespace ScreenSound
{
    public class Musica(string nome, Banda artista, int duracao, bool disponivel)
    {
        public string Nome { get;  } = nome;
        public Banda Artista { get; } = artista;
        public int Duracao { get; } = duracao;
        public bool Disponivel { get; } = disponivel;

        public void ShowMusic()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Artista: {Artista.Nome}");
            Console.WriteLine($"Duração: {Duracao} segundos");
            if (Disponivel)
            {
                Console.WriteLine("Disponível: Sim");
            }
            else
            {
                Console.WriteLine("Adquira o plano");
            }
        }
    }
}