using System;

class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int[] arr = new int[a];

        string numbers = Console.ReadLine();
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = numbers[i] - '0'; 
        }

        int sum = 0;
        foreach (int i in arr) 
        {
            sum += i;
        }
        Console.WriteLine(sum);
    }
}
