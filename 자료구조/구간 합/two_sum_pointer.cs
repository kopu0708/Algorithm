using System;

class IngredientCollector
{
    private int numOfitem;
    private int collect;
    private int[] ingredients;
    private int start;
    private int end;
    private int answer;
    public int NumOfitem { get { return numOfitem; } }
    public int Collect { get { return collect; } }
    public int[] Ingredients { get { return ingredients; } }
    public int Answer { get { return answer; } }

    public IngredientCollector(int numOfitem, int collect, int[] ingredients)
    {
        this.numOfitem = numOfitem;
        this.collect = collect;
        this.ingredients = ingredients;
        this.start = 0;
        this.end = numOfitem - 1;
        this.answer = 0;
    }
    
    public int Solve()
    {
        Array.Sort(ingredients);

        while(start < end)
        {
            if (ingredients[start] + ingredients[end] > collect)
            {
                end--;
            }
            else if (ingredients[start] + ingredients[end] < collect)
            {
                start++;
            }
            else
            {
                answer++;
                start++; end--;
            }
        }
        return answer;
    }
}

class Program
{
    static void Main()
    {
        int numOfitem = int.Parse(Console.ReadLine());
        int collect = int.Parse(Console.ReadLine());
        int[] ingredients = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        IngredientCollector ingredientCollector = new IngredientCollector(numOfitem, collect, ingredients);
        Console.WriteLine(ingredientCollector.Solve());
    }
}
