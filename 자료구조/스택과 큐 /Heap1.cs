using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        PriorityQueue<int,(int,int)> queue = new PriorityQueue<int, (int, int)>();
        StringBuilder answer = new StringBuilder();
        int[] arr = new int[input];

        for(int i =0; i<input; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
            
            if (arr[i] == 0 && queue.Count == 0)
            {
                answer.AppendLine("0");
            }
            else if (arr[i] == 0 && queue.Count > 0)
            {
                int temp = queue.Dequeue();
                answer.AppendLine(temp.ToString());
            }

            else if (arr[i] != 0 )
            { 
                queue.Enqueue(arr[i], (Math.Abs(arr[i]), arr[i]));
            }
        }

        Console.WriteLine(answer);
    }
}
