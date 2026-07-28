using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int[] a = Array.ConvertAll(input.Split(' '), int.Parse); // 배열 크기, 질의 개수

        int[] arr = new int[a[0]];

        string arrinput = Console.ReadLine();
        arr = Array.ConvertAll(arrinput.Split(' '), int.Parse);

        int[] prefix = new int[arr.Length + 1]; // prefix sum 배열
        for(int i = 1; i < prefix.Length; i++)
        {
            prefix[i] = prefix[i - 1] + arr[i - 1];
        }

        for (int i = 0; i < a[1]; i++)
        {
            string queryInput = Console.ReadLine();
            int[] query = Array.ConvertAll(queryInput.Split(' '), int.Parse); // 질의 입력
            int answer = prefix[query[1]] - prefix[query[0] - 1]; // 구간 합 계산

            Console.WriteLine(answer);
        }
    }
}
