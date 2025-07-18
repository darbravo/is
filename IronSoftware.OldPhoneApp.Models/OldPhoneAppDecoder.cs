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

    /// <summary>
    /// Iterates the list of given tokens (assumed valid) and decodes the text.
    /// </summary>
    /// <param name="tokens"></param>
    /// <returns></returns>
    public static string Decode(List<string> tokens)
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
}
