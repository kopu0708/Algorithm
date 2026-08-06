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

----
// 2026-08-06 
// 다시 풀어봤다. 그 과정에서 위 코드가 prefix 배열의 0번째를 포함하지 않고 풀어 첫 인덱스를 포함하는 나눠지는 합들은 따로 새어줬는데 
// 아래 코드와 같이짜면 상당히 이해하기 편해지고 코드가 짧아졌다.

using System;


class Program
{
    static void Main()
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        int N = input[0];
        int K = input[1];
        int[] arr = new int[N];
        arr = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        long answer = 0;

        int[] prefix = new int[N + 1];
        for(int i = 0; i < N; i++)
        {
            prefix[i + 1] = prefix[i] + arr[i]; 
        }

        int[] freq = new int[K]; // 나눠주는 수 이상의 숫자는 안나오니깐 K까지만 만들어주고 
        for(int i = 0; i <= N; i++)
        {
            freq[prefix[i] % K]++; // 각 인데스가 해당 나머지 수가 몇번 나왔는지를 나타냄
        }

        foreach (int cnt in freq)
        {
            answer += (long)cnt * (cnt - 1) / 2;
        }



        Console.WriteLine(answer);
    }
}
