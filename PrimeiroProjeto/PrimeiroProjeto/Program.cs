// Screen Sound

using System.Collections;

string welcomeMessage = "Boas vindas ao Screen Sound";

//List<string> bands = new List<string> { "U2", "Beatles", "Japanese Breakfast" };
Dictionary<string, List<int>> bands = new Dictionary<string, List<int>>();
bands.Add("U2", new List<int> { 10, 9, 8 });
bands.Add("Beatles", new List<int> { 10, 9, 8 });
bands.Add("Japanese Breakfast", new List<int> { 10, 9, 8 });

void PrintWelcomeMessage() 
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝

░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(welcomeMessage);
}

void ShowMenuOptions()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string userOption = Console.ReadLine()!;
    int userOptionInt = int.Parse(userOption);

    switch (userOptionInt)
    {
        case 1:
            RegisterBand();
            break;
        case 2:
            ShowBands();
            break;
                case 3:
            ReviewBand();
            break;
        case 4:
            Console.WriteLine("Voce escolheu a opção: " + userOption);
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção Inválida");
            break;
    }
}

void aproved()
{   
    Console.WriteLine("Digite sua nota da prova: ");
    string userNote = Console.ReadLine()!;
    int userAverage = int.Parse(userNote);
    if (userAverage >= 5)
    { 
        Console.WriteLine("Aprovado");
    }
    else
    {
        Console.WriteLine("Reprovado");
    }
    
}

void RegisterBand()
{
    Console.Clear();
    Console.WriteLine("*********");
    Console.WriteLine("Registro de bandas");
    Console.WriteLine("*********");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string bandName = Console.ReadLine()!;
    bands.Add(bandName, new List<int>());
    Console.WriteLine($"A banda {bandName}, foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ShowMenuOptions();
}


void ShowBands()
{
    Console.WriteLine("Exibindo todas as bandas:");
    foreach (string b in bands.Keys) 
    {
        Console.WriteLine($"Bandas: {b}, ");
    }
    Console.WriteLine("Digite alguma tecla para sair: ");
    Console.ReadKey();
    ShowMenuOptions();
}

void ReviewBand()
{
    Console.Clear();
    Console.Write("Avaliar Banda");
    string bandName = Console.ReadLine()!;
    if (bands.ContainsKey(bandName)){
        Console.WriteLine("Digite uma nota para a banda de 1 a 10");
        int review = int.Parse(Console.ReadLine()!);
        bands[bandName].Add(review);
        Console.WriteLine($"\nA nota da banda {bandName} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        ShowMenuOptions();

    } else
    {
        Console.WriteLine($"A banda {bandName}, não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }

}

PrintWelcomeMessage();
ShowMenuOptions();




