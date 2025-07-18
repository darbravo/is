

namespace IronSoftware.OldPhoneApp.Models;

public class InputValidator
{
    public static void Validate(string input)
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
}