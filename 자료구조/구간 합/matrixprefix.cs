using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int[] a = Array.ConvertAll(input.Split(' '), int.Parse);

        int[,] matrix = new int[a[0], a[0]];

        for(int i = 0; i < a[0]; i++)
        {
            string[] row = Console.ReadLine().Split(' ');
            for (int j = 0; j < a[0]; j++)
            {
                matrix[i, j] = int.Parse(row[j]);
            }
        }

        int[,] prefix = new int[a[0] + 1, a[0] + 1];

        for(int i = 1; i < a[0] + 1; i++)
        {
            for(int j = 1; j < a[0] + 1; j++)
            {
                prefix[i, j] = prefix[i, j - 1] + prefix[i - 1, j] - prefix[i - 1, j - 1] + matrix[i - 1, j - 1]; 
            }
        }

        for(int i = 0; i < a[1]; i++)
        {
            string answer = Console.ReadLine();
            int[] xy = Array.ConvertAll(answer.Split(' '), int.Parse);

            int result = prefix[xy[2], xy[3]] - prefix[xy[0] - 1, xy[3]] - prefix[xy[2] , xy[1] - 1] + prefix[xy[0] - 1, xy[1] - 1];

            Console.WriteLine(result);
        }

       
    }
}
