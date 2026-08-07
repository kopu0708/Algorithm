using System;
class GoodNumberFinder
{
    private int number;
    private long[] arr;
    private int target;
    private int answer;
    public int Number { get { return number; } }
    public long[] Arr { get { return arr; } }
    public int Target { get { return target; } }
    public int Answer { get { return answer; } }

    public GoodNumberFinder(int number, long[] arr)
    {
        this.number = number;
        this.arr = arr;
        this.target = 0;
        this.answer = 0;

    }

    public int Solve()
    {
        Array.Sort(arr);
        while (target < number)
        {
            int start = 0;
            int end = number - 1;

            while (start < end)
            {
                if (start == target) { start++; continue; }
                if (end == target) { end--; continue; }

                long sum = arr[start] + arr[end];

                if (sum == arr[start] + arr[end])
                {
                    answer++;
                    break;
                }
                else if (sum < arr[target])
                {
                    start++;
                }

                else
                {
                    end--;
                }
            }

        }
        return answer;
    }

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            GoodNumberFinder finder = new GoodNumberFinder(n, arr);
            Console.WriteLine(finder.Solve());
        }
    }
}
