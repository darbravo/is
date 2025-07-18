using IronSoftware.OldPhoneApp.Models;

namespace IronSoftware.OldPhoneApp.Cli;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Iron Software - Sales Engineer role challenge");
        Console.WriteLine("Dario Bravo <darbravo@gmail.com>");
        Console.WriteLine();
        Console.WriteLine("Type 'quit' to quit.");

        while (true)
        {
            Console.Write("> ");

            var input = Console.ReadLine();

            if (input == null) continue;

            input = input.ToLowerInvariant().Trim();

            if (string.IsNullOrEmpty(input)) continue;

            if (input == "quit")
            {
                Console.WriteLine("Bye!");
                break;
            }

            try
            {
                DecodeInput(input);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
            }
        }
    }

    private static void DecodeInput(string input)
    {
        var oldPhoneText = OldPhoneAppDecoder.DecodeInput(input);
        Console.WriteLine(oldPhoneText);
    }
}
