using System;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Array.Sort(arr);

        int start = 0;
        int end = N - 1;
        int find = 0;
        int answer = 0;
        
        while(find != N)
        {
            start = 0;
            end = N - 1;

            while (start < end)
            {
                if (start == find) { start++; continue; }
                if (end == find) { end--; continue; }

                if (arr[start] + arr[end] == arr[find])
                {
                    answer++;
                    break;
                }   
                else if (arr[start] + arr[end] < arr[find])
                    start++;
                else
                    end--;
            }
            find++;
        }
        Console.WriteLine(answer);
    }
}
