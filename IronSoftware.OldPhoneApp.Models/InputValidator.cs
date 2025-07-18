

namespace IronSoftware.OldPhoneApp.Models;

public class InputValidator
{
    /// <summary>
    /// Validates several rules for input.
    /// - Cant be null, empty or white space
    /// - Must be only allowed characters
    /// - Must end with #
    /// - Must have only one #
    /// - Cannot have a space following another
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="ArgumentException"></exception>
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