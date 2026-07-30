using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int[] a = Array.ConvertAll(input.Split(' '), int.Parse);
        int N = a[0]; // 배열 길이
        int K = a[1]; // 나눌 수
        int[] array = new int[N]; // 배열 만들고 

        string input2 = Console.ReadLine();
        string[] values = input2.Split(' ');

        for(int i = 0; i < N; i++) //배열에 정수형으로 넣고
        {
            array[i] = int.Parse(values[i]);
        }

        int[] prefix = new int[N + 1];
        for(int i = 1; i < N + 1; i++)
        {
            prefix[i] = prefix[i - 1] + array[i - 1];  // 0 1 3 6 7 9             (1,2,3,1,2 일때)
        }

        int[] remain = new int[N];


        long answer = 0;

        for (int i = 0; i < N; i++)
        {
            remain[i] = prefix[i + 1] % K;
            if (remain[i] == 0)
                answer += 1;
        }

        int[] freq = new int[K]; // N개의 칸, 각 칸은 "그 나머지가 몇 번 나왔는지"

        foreach (int r in remain)
        {
            freq[r]++;
        }

        foreach (int cnt in freq)
        {
            answer += (long)cnt * (cnt - 1) / 2;
        }

        Console.WriteLine(answer);

    }
}
