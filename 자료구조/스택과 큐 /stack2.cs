using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        int[] arr = new int[size];
        int[] answer = new int[size];

        arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        Array.Fill(answer, -1);
        Stack<int> stack = new Stack<int>();


        for (int i = 0; i < size; i++)
        {
            while(stack.Count > 0 && arr[i] > arr[stack.Peek()])    
            {
                int idx = stack.Pop();
                answer[idx] = arr[i];

            }
            stack.Push(i);

            
        }
        for(int i = 0; i < size; i++)
        {   
            Console.Write(answer[i] + " ");
        }
    }
}
