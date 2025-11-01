namespace SomeLib;

public class Calc
{
    public static int CheckedAdd(int a, int b)
    {
        checked
        {
            return a + b;
        }
    }

    public static int SaturatingAdd(int a, int b)
    {
        if (b > 0 && a > int.MaxValue - b)  return int.MaxValue;
        if (b < 0 && a < int.MinValue - b)  return int.MinValue;
        return a + b;
    }
}