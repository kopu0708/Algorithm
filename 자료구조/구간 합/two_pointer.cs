using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        int Q = int.Parse(input);

        int[] arr = new int[Q]; 

        for(int i = 0; i < Q; i++) 
        {
            arr[i] = i + 1;
        }

        int answer = 1;

        int start_index = 0;
        int end_index = 0;
        int sum = 1;

        while(end_index != Q - 1) // 끝에 도달할때까지 
        {
            if(sum == Q)
            {
                answer++; end_index++;
                sum += arr[end_index]; // 같을 때는 새주고 올려서 더해준다.
            }
            else if (sum < Q)
            {
                end_index++;
                sum += arr[end_index]; //더할 때는 올리고 더해주고 
                
            }
            else if (sum > Q)
            {
                sum -= arr[start_index]; // 뺄때는 올리기전에 빼주고 
                start_index++; 

            }
        }

        Console.WriteLine(answer);
    }
}
