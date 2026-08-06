using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        Queue<int> que = new Queue<int>();

        for(int i = 0; i<input; i++)
        {
            que.Enqueue(i + 1);
        }

        int count = 1;

        while (que.Count > 1)
        {
            if(count%2 != 0)
            {
                que.Dequeue();

            }

            else
            {
               int a = que.Dequeue();
               que.Enqueue(a);
            }
            count++;
        }

        Console.WriteLine(que.Dequeue());
    }
}
