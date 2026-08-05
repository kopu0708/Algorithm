using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int[] target = new int[a];

        for(int i = 0; i < a; i++)
        {
            target[i] = int.Parse(Console.ReadLine());
        }

        Stack<int> stack = new Stack<int>();
        int count = 1;
        StringBuilder answer = new StringBuilder();
        bool flag = true;
        for(int i = 0; i < a; i++)
        {
            while (count <= target[i]) 
            {
                stack.Push(count);
                answer.AppendLine("+");
                count++;
            }
            if (stack.Peek() == target[i])
            {
                stack.Pop();
                answer.AppendLine("-");
            }

            else
            {
                Console.WriteLine("NO");
                flag = false;
                break;
            }
        }

        if(flag == true)
        {
            Console.WriteLine(answer);
        }
       
    }
}
