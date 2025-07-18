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
                Console.WriteLine(OldPhonePad(input));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
            }
        }
    }

    public static string OldPhonePad(string input)
    {
        InputValidator.Validate(input);
        var tokens = Tokenizer.Tokenize(input);
        return OldPhoneAppDecoder.Decode(tokens);
    }
}
