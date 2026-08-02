using System;

class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Array.Sort(arr); // 오르차순 정렬

        int start = 0;
        int end = N - 1;
        int answer = 0;
        while(start < end)
        {
            if (arr[start] + arr[end] > M)
            {
                end--;
            }
            else if (arr[start] + arr[end] < M)
            {
                start++;
            }
            else if (arr[start] + arr[end] == M)
            {
                answer++;
                start++; end--;
            }
        }

        Console.WriteLine(answer);
    }
}
