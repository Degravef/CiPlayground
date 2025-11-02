using SomeLib;

namespace SomeLibTest;

public class UnitTest1
{
    [Theory]
    [InlineData(1, 2, 3)]
    // [InlineData(0, 0, 0)]
    public void TestCheckedAdd(int a, int b, int expected)
    {
        int result = Calc.CheckedAdd(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, int.MaxValue)]
    // [InlineData(int.MaxValue, 1)]
    // [InlineData(-1, int.MinValue)]
    // [InlineData(int.MinValue, -1)]
    public void TestCheckedAddOverflow(int a, int b)
    {
        Assert.Throws<OverflowException>(() => Calc.CheckedAdd(a, b));
    }
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, -2, -3)]
    [InlineData(5, -3, 2)]
    [InlineData(-10, 15, 5)]
    [InlineData(100, 200, 300)]
    [InlineData(int.MaxValue, 0, int.MaxValue)]
    [InlineData(int.MinValue, 0, int.MinValue)]
    [InlineData(int.MaxValue - 1, 1, int.MaxValue)]
    [InlineData(int.MinValue + 1, -1, int.MinValue)]
    [InlineData(int.MaxValue, 1, int.MaxValue)]
    [InlineData(int.MinValue, -1, int.MinValue)]
    public void TestSaturatingAdd(int a, int b, int expected)
    {
        int result = Calc.SaturatingAdd(a, b);
        Assert.Equal(expected, result);
    }
}