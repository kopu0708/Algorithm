using System;

class Program
{
    static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine());

        int[] arr = new int[x];

        string input = Console.ReadLine();

        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(input.Split(" ")[i]);
        }

        double[] arr2 = new double[x];

        for (int i = 0; i < arr2.Length; i++)
        {
            arr2[i] = ((double)arr[i] / arr.Max()) * 100;
        }

        double result = arr2.Sum() / arr2.Length;
        Console.WriteLine(result);
    }
}
