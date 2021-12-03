// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Globalization;

namespace Day03;
public class Program
{
    public static void Main()
    {
        string? line;
        int width = 0;
        int[]? bitCount = null;
        int lineCount = 0;
        while ((line = Console.ReadLine()) is not null)
        {
            line = line.Trim();
            lineCount += 1;
            if (width == 0)
            {
                width = line.Length;
                bitCount = new int[width];
            }
            Debug.Assert(bitCount is not null);
            line.ToList().ForEach(c => Debug.Assert(c is '0' or '1'));
 
            for (int i = bitCount.Length - 1; i >= 0; i--)
            {
                if (line[i] is '1')
                {
                    bitCount[i] += 1;
                }
            }
        }

        Debug.Assert(bitCount is not null);
        bool[] bits = new bool[bitCount.Length];
        for (int i = 0; i < bits.Length; i++)
        {
            bits[i] = bitCount[i] > lineCount / 2;
        }

        int gamma = ConvertToInt(bits);
        for (int i = 0; i < bitCount.Length; i++)
        {
            bits[i] = !bits[i];
        }

        int epsilon = ConvertToInt(bits);

        Console.WriteLine($"Result: {gamma * epsilon}");
    }

    private static int ConvertToInt(bool[] bits)
    {
        int value = 0;
        int positionValue = 1;
        for (int i = bits.Length - 1; i >= 0; i--)
        {
            if (bits[i])
            {
                value += positionValue;
            }

            positionValue *= 2;
        }

        return value;
    }
}