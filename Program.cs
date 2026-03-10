using System;

class Program
{
    static int vitorias = 0;
    static int derrotas = 0;
    static int empates = 0;

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Digite o nome do jogador:");
        string jogador = Console.ReadLine();

        char continuar = '1';

        while (continuar == '1')
        {
            Jogar(jogador);

            Console.WriteLine("\nQuer jogar de novo?");
            Console.WriteLine("1 - Sim | 0 - Não | 2 - Trocar jogador");

            continuar = Console.ReadKey().KeyChar;

            if (continuar == '2')
            {
                Console.WriteLine("\nDigite o novo jogador:");
                jogador = Console.ReadLine();
                continuar = '1';
            }
        }

        MostrarEstatisticas(jogador);
        Console.WriteLine("\n👋 Até a próxima!");
    }

    static void Jogar(string jogador)
    {
        int opcao = ValidarEntrada();

        int opcaoPC = new Random().Next(3);

        Console.WriteLine($"\n{jogador} escolheu {TraduzirOpcao(opcao)}");
        Console.WriteLine($"Computador escolheu {TraduzirOpcao(opcaoPC)}");

        if (opcao == opcaoPC)
        {
            Console.WriteLine("Empate!");
            empates++;
        }
        else if (
            (opcao == 0 && opcaoPC == 2) ||
            (opcao == 1 && opcaoPC == 0) ||
            (opcao == 2 && opcaoPC == 1))
        {
            Console.WriteLine("Você venceu!");
            vitorias++;
        }
        else
        {
            Console.WriteLine("Computador venceu!");
            derrotas++;
        }
    }

    static int ValidarEntrada()
    {
        int opcao;

        while (true)
        {
            Console.WriteLine("\nEscolha:");
            Console.WriteLine("0 - Pedra ✊");
            Console.WriteLine("1 - Papel ✋");
            Console.WriteLine("2 - Tesoura ✌");

            if (int.TryParse(Console.ReadLine(), out opcao) && opcao >= 0 && opcao <= 2)
                return opcao;

            Console.WriteLine("Entrada inválida. Tente novamente.");
        }
    }

    static string TraduzirOpcao(int opcao)
    {
        switch (opcao)
        {
            case 0: return "Pedra ✊";
            case 1: return "Papel ✋";
            case 2: return "Tesoura ✌";
            default: return "";
        }
    }

    static void MostrarEstatisticas(string jogador)
    {
        Console.WriteLine("\n===== Estatísticas =====");
        Console.WriteLine($"Jogador: {jogador}");
        Console.WriteLine($"Vitórias: {vitorias}");
        Console.WriteLine($"Derrotas: {derrotas}");
        Console.WriteLine($"Empates: {empates}");
    }
}