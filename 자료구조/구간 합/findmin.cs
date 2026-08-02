using System;
 
class Program
{
    static void Main(string[] args)
    {
        int[] NL = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
 
        int Head = 0;
        int Tail = NL[1] - 1;
 
        int min = 100000000;
        for (int i = Head; i <= Tail; i++)
        {
            if (min > arr[i]) { min = arr[i]; }
        }
        Console.Write(min + " ");
 
        while (Tail < arr.Length)
        { 
            if (Tail == NL[0] - 1) break;
            if (arr[Head] == min) //빠지는 값이 최솟값이면 다시 찾아야함 
            {
                min = 100000000;
                for (int i = Head + 1; i <= Tail+1; i++)
                {
                    if (min > arr[i]) { min = arr[i]; }
                }
            } 
            else { min = arr[Tail + 1] > min ? min : arr[Tail + 1]; } // 아니면 그냥 기존 최솟값이랑 새로 들어오는 값을 비교하자
            Head++; Tail++;
            Console.Write(min + " ");
        }
    }
}
