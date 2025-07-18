using IronSoftware.OldPhoneApp.Models;

namespace IronSoftware.OldPhoneApp.Tests;

[TestClass]
public class OldPhoneAppDecoderTests
{
    [TestMethod]
    public void SingleNumbers_ShouldBe_SingleLetters()
    {
        var decoded = OldPhoneAppDecoder.Decode(["2", "3", "4"]);
        var expected = "ADG";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void Example1_ShouldBe_E()
    {
        var decoded = OldPhoneAppDecoder.Decode(["33"]);
        var expected = "E";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void Example2_ShouldBe_B()
    {
        var decoded = OldPhoneAppDecoder.Decode(["22", "7", "*"]);
        var expected = "B";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void Example3_ShouldBe_HELLO()
    {
        var decoded = OldPhoneAppDecoder.Decode(["44", "33", "555", "555", "666"]);
        var expected = "HELLO";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void Example4_ShouldBe_TURING()
    {
        var decoded = OldPhoneAppDecoder.Decode(["8", "88", "777", "444", "666", "*", "66", "4"]);
        var expected = "TURING";

        Assert.AreEqual(expected, decoded);
    }

    [TestMethod]
    public void FourEights_ShouldBe_OneEight()
    {
        var decoded = OldPhoneAppDecoder.Decode(["8888"]);
        var expected = "T";

        Assert.AreEqual(expected, decoded);
    }
}
