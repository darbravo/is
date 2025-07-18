using IronSoftware.OldPhoneApp.Models;

namespace IronSoftware.OldPhoneApp.Tests;

[TestClass]
public class InputValidatorTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullInput_ShouldThrow()
    {
        InputValidator.Validate(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmptyInput_ShouldThrow()
    {
        InputValidator.Validate(string.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void WhitespaceInput_ShouldThrow()
    {
        InputValidator.Validate(" ");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidInput_ShouldThrow()
    {
        InputValidator.Validate("ABC");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidInput2_ShouldThrow()
    {
        InputValidator.Validate("8737@");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UnfinishedInput_ShouldThrow()
    {
        InputValidator.Validate("8737");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ExtraSpaces_ShouldThrow()
    {
        InputValidator.Validate("8    2#");
    }
}
