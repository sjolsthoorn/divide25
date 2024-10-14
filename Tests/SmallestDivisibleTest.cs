using Divide25.Controllers;
using Divide25.Services;
using Xunit;

public class SmallestDivisibleTests
{
    [Fact]
    public void TestSmallestDivisibleBy1To10()
    {
        var controller = new DivisibleService();
        long result = controller.GetSmallestNumberDivisibleByRange(1, 10);
        Assert.Equal(2520, result);
    }

    [Fact]
    public void TestSmallestDivisibleBy1To25()
    {
        var controller = new DivisibleService();
        long result = controller.GetSmallestNumberDivisibleByRange(1, 25);
        Assert.Equal(26771144400, result);
    }
}
