using System;

class Program
{
    static void Main(string[] args)
    {
        int answer = 0;
        string input = Console.ReadLine();
        int[] SP = Array.ConvertAll(input.Split(' '), int.Parse);

        string DNA = Console.ReadLine();

        int[] ACGT = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int Head = 0;
        int Tail = SP[1] - 1;

        int A = 0;
        int C = 0;
        int G = 0;
        int T = 0;

        for (int i = Head; i <= Tail; i++)
        {
            if (DNA[i] == 'A') { A++; }
            else if (DNA[i] == 'C') { C++; }
            else if (DNA[i] == 'G') { G++; }
            else if (DNA[i] == 'T') { T++; }
        }
        while (Tail < DNA.Length)
        {
            if(A >= ACGT[0] && C >= ACGT[1] && G >= ACGT[2] && T >= ACGT[3]) {answer++;}

            if (Tail == DNA.Length - 1) break;

            if (DNA[Head] == 'A') { A--; }
            else if (DNA[Head] == 'C') { C--; }
            else if (DNA[Head] == 'G') { G--; }
            else if (DNA[Head] == 'T') { T--; }

            if (DNA[Tail + 1] == 'A') { A++; }
            else if (DNA[Tail + 1] == 'C') { C++; }
            else if (DNA[Tail + 1] == 'G') { G++; }
            else if (DNA[Tail + 1] == 'T') { T++; }

            Head++; Tail++;

        }
        Console.WriteLine(answer);
    }
}
