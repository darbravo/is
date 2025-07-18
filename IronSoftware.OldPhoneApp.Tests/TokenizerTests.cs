using IronSoftware.OldPhoneApp.Models;

namespace IronSoftware.OldPhoneApp.Tests;

[TestClass]
public class TokenizerTests
{
    [TestMethod]
    public void SplitToken_ShouldBe_Ok()
    {
        var tokens1 = Tokenizer.Tokenize("33#");
        Assert.IsTrue(new List<string> { "33" }.SequenceEqual(tokens1));

        var tokens2 = Tokenizer.Tokenize("227*#");
        Assert.IsTrue(new List<string> { "22", "7", "*" }.SequenceEqual(tokens2));

        var tokens3 = Tokenizer.Tokenize("4433555 555666#");
        Assert.IsTrue(new List<string> { "44", "33", "555", "555", "666" }.SequenceEqual(tokens3));

        var tokens4 = Tokenizer.Tokenize("8 88777444666*664#");
        Assert.IsTrue(new List<string> { "8", "88", "777", "444", "666", "*", "66", "4" }.SequenceEqual(tokens4));
    }
}