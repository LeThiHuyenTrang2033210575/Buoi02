using System;

class Program
{
    static void Main(string[] args)
    {
        long x = 7853;
        long y = 2341;

        Console.WriteLine("Original numbers:");
        Console.WriteLine("X = " + x);
        Console.WriteLine("Y = " + y);

        long result = Multiply(x, y);

        Console.WriteLine("Result: " + result);
    }

    static long Multiply(long x, long y)
    {
        int n = (int)Math.Ceiling(Math.Log10(x));
        int m = (int)Math.Ceiling(Math.Log10(y));

        int maxDigits = Math.Max(n, m);

        if (maxDigits <= 1) return x * y;

        int halfDigits = maxDigits / 2;

        long a = x / (long)Math.Pow(10, halfDigits);
        long b = x % (long)Math.Pow(10, halfDigits);

        long c = y / (long)Math.Pow(10, halfDigits);
        long d = y % (long)Math.Pow(10, halfDigits);

        long ac = Multiply(a, c);
        long ad = Multiply(a, d);
        long bc = Multiply(b, c);
        long bd = Multiply(b, d);

        return ac * (long)Math.Pow(10, 2 * halfDigits) +
               (ad + bc) * (long)Math.Pow(10, halfDigits) +
               bd;
    }
}