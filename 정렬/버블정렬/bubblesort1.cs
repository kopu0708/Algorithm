using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var arr = new (int value, int index)[n];
        for(int i = 0; i < n; i++)
        {
            arr[i] = (int.Parse(Console.ReadLine()),i); 
        }

        var sorted = arr.OrderBy(x => x.value).ToArray();

        int Max = 0;

        for(int rank = 0; rank < n; rank++)
        {
            int diff = sorted[rank].index - rank;
            if (diff > Max) Max = diff;
        }

        Console.WriteLine(Max + 1);
    }
}
