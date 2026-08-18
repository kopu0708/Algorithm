using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for(int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }   
        int temp = 0;
        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < n - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

        foreach(int a in arr)
        {
            Console.WriteLine(a);
        }
    }
}
