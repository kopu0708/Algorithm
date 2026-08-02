using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[] NL = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        LinkedList<int> deque = new LinkedList<int>();

        for(int i = 0; i< NL[0]; i++)
        {
          while(deque.Count > 0 && arr[deque.Last.Value] >= arr[i])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i); // 인덱스 번호를 저장함 

            if(deque.First.Value <= i - NL[1])
            {
                deque.RemoveFirst();
            }

            if(i >= NL[1] - 1)
            {
                Console.Write(arr[deque.First.Value] + " ");
            }
        }
    }
}
