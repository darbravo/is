using IronSoftware.OldPhoneApp.Models;

namespace IronSoftware.OldPhoneApp.Tests;

[TestClass]
public class OldPhoneAppDecoderTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void NullInput_ShouldThrow()
    {
        OldPhoneAppDecoder.DecodeInput(null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmptyInput_ShouldThrow()
    {
        OldPhoneAppDecoder.DecodeInput(string.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void WhitespaceInput_ShouldThrow()
    {
        OldPhoneAppDecoder.DecodeInput(" ");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidInput_ShouldThrow()
    {
        OldPhoneAppDecoder.DecodeInput("ABC");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidInput2_ShouldThrow()
    {
        OldPhoneAppDecoder.DecodeInput("8737@");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UnfinishedInput_ShouldThrow()
    {
        OldPhoneAppDecoder.DecodeInput("8737");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ExtraSpaces_ShouldThrow()
    {
        OldPhoneAppDecoder.DecodeInput("8    2#");
    }

    [TestMethod]
    public void SingleNumbers_ShouldBe_SingleLetters()
    {
        var decoded = OldPhoneAppDecoder.DecodeInput("234#");
        var expected = "ADG";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void Example1_ShouldBe_E()
    {
        var decoded = OldPhoneAppDecoder.DecodeInput("33#");
        var expected = "E";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void Example2_ShouldBe_B()
    {
        var decoded = OldPhoneAppDecoder.DecodeInput("227*#");
        var expected = "B";

        Assert.AreEqual(expected, decoded);
    }
    
    [TestMethod]
    public void Example3_ShouldBe_HELLO()
    {
        var decoded = OldPhoneAppDecoder.DecodeInput("4433555 555666#");
        var expected = "HELLO";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void Example4_ShouldBe_TURING()
    {
        var decoded = OldPhoneAppDecoder.DecodeInput("8 88777444666*664#");
        var expected = "TURING";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void FourEights_ShouldBe_OneEight()
    {
        var decoded = OldPhoneAppDecoder.DecodeInput("8888#");
        var expected = "T";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void SplitToken_ShouldBe_Ok()
    {
        var tokens1 = OldPhoneAppDecoder.SplitTokens("33#");
        Assert.IsTrue(new List<string> { "33" }.SequenceEqual(tokens1));

        var tokens2 = OldPhoneAppDecoder.SplitTokens("227*#");
        Assert.IsTrue(new List<string> { "22", "7", "*" }.SequenceEqual(tokens2));

        var tokens3 = OldPhoneAppDecoder.SplitTokens("4433555 555666#");
        Assert.IsTrue(new List<string> { "44", "33", "555", "555", "666" }.SequenceEqual(tokens3));

        var tokens4 = OldPhoneAppDecoder.SplitTokens("8 88777444666*664#");
        Assert.IsTrue(new List<string> { "8", "88", "777", "444", "666", "*", "66", "4" }.SequenceEqual(tokens4));
    }
}