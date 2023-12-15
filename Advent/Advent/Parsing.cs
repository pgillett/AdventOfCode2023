using System;
using System.Runtime.CompilerServices;

namespace Advent;

public class Parsing
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Int(ReadOnlySpan<char> input)
    {
        var result = 0;
        foreach (var c in input)
        {
            result = (result << 3) + (result << 1) + (c - '0');
        }

        return result;
    }
}