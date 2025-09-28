using System.Globalization;

public struct Pessoa
{
    public string NomeCompleto;
    public DateTime DataNascimento;


    public int CalcularIdade()
    {
        DateTime dataAtual = DateTime.Today;
        int idade = dataAtual.Year - DataNascimento.Year;

        if (DataNascimento.Date > dataAtual.AddYears(-idade))
        {
            idade--;
        }

        return idade;
    }

    public bool EhMaiorDeIdade()
    {
        return CalcularIdade() >= 18;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pessoa usuario = new Pessoa();

            Console.WriteLine("Digite seu nome completo:");
            usuario.NomeCompleto = Console.ReadLine();

            Console.WriteLine("Digite sua data de nascimento (formato dd/MM/yyyy):");
            string dataInput = Console.ReadLine();
            usuario.DataNascimento = DateTime.ParseExact(dataInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            int idadeCalculada = usuario.CalcularIdade();

            Console.WriteLine($"\nOlá, {usuario.NomeCompleto}.");
            Console.WriteLine($"Sua idade atual é: {idadeCalculada} anos.");

            if (usuario.EhMaiorDeIdade())
            {
                Console.WriteLine("Você é maior de idade.");
                Console.WriteLine("Você já pode iniciar o processo para tirar sua carteira de habilitação.");
            }
            else
            {
                Console.WriteLine("Você é menor de idade.");
                Console.WriteLine("Você ainda não pode iniciar o processo para tirar a carteira de habilitação.");
            }
        }
    }
}