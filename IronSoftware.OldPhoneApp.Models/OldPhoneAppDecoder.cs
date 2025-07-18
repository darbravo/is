
namespace IronSoftware.OldPhoneApp.Models;

public class OldPhoneAppDecoder
{
    static Dictionary<string, string> keypad =
    new() {
        { "1", "&'(" },
        { "2", "ABC" },
        { "3", "DEF" },
        { "4", "GHI" },
        { "5", "JKL" },
        { "6", "MNO" },
        { "7", "PQRS" },
        { "8", "TUV" },
        { "9", "WXYZ" },
        { "*", "" },
        { "0", " " },
        { "#", "" }
    };

    public static string DecodeInput(string input)
    {
        ValidateInput(input);

        var tokens = SplitTokens(input);

        return TranslateTokens(tokens);
    }

    private static string TranslateTokens(List<string> tokens)
    {
        var letters = string.Empty;

        foreach (var token in tokens)
        {
            // special case: delete
            if (token == "*")
            {
                if (letters.Length > 0)
                {
                    letters = letters.Substring(0, letters.Length - 1);
                }

                continue;
            }

            var pressedKey = token[0].ToString();
            var sanitizedToken = token;

            // special case: many times the same key without a space
            if (keypad[pressedKey].Length < token.Length)
            {
                // Dario Bravo: I never thought I'd use new string(char, int)
                sanitizedToken = new string(token[0], token.Length % keypad[pressedKey].Length);
            }

            var letter = keypad[pressedKey].ElementAt(sanitizedToken.Length - 1);
            letters += letter;
        }

        return letters;
    }

    private static void ValidateInput(string input)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(input);

        var valid = true;

        const string allowedInput = "0123456789#* ";

        valid = valid && input.All(x => allowedInput.Contains(x));
        valid = valid && input.EndsWith("#");
        valid = valid && input.Count(x => x == '#') == 1;
        valid = valid && !input.Contains("  ");

        if (!valid)
        {
            throw new ArgumentException(nameof(input));
        }
    }

    public static List<string> SplitTokens(string input)
    {
        var tokens = new List<string>();
        var currentToken = string.Empty;

        for (var i = 0; i < input.Length; i++)
        {
            var c = input[i];

            if ((currentToken.Length == 4 || (currentToken.Length > 0 && currentToken[^1] != c) || c == ' ') && !string.IsNullOrWhiteSpace(currentToken))
            {
                tokens.Add(currentToken);
                currentToken = string.Empty;
            }

            if (c == '#')
            {
                break;
            }

            if (c == ' ')
            {
                continue;
            }

            if (currentToken.Length == 0 && c != ' ')
            {
                currentToken += c;
                continue;
            }

            if (currentToken[^1] == c && currentToken.Length < 4)
            {
                currentToken += c;
                continue;
            }
        }

        return tokens;
    }
}
