using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };

        int[] prefix = new int[arr.Length + 1];

        for(int i = 0; i < arr.Length; i++)
        {
            prefix[i + 1] = prefix[i] + arr[i];
        }
    }
}
