// N개의 숫자가 공백없이 쓰여 있다. 이 숫자를 모두 합해 출력하는 프로그램
// 1번째 줄에 숫자의 개수 N(1 <= N <= 100), 2번째 줄에 숫자 N개가 공백 없이 주어진다.
// 출력은 숫자 N개의 합 

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
