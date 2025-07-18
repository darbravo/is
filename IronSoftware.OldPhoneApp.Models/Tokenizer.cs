namespace IronSoftware.OldPhoneApp.Models;

public class Tokenizer
{
    public static List<string> Tokenize(string input)
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