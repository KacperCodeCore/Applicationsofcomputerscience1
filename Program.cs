const int N = 8;
const int B = 20;

int[] values = new int[N];
int[] weights = new int[N];

int[] solution = new int[N];

Random random = new Random();


int bestSolutionValue = int.MinValue;
int[] BestSolution = new int[N];


List<int> soulutionValues = new List<int>();




Console.WriteLine("Values:");
for (int i = 0; i < N; i++)
{
    values[i] = random.Next(1, B / 2);
    Console.Write($"{values[i]}, ");

}
Console.WriteLine();
Console.WriteLine("Weights:");
for (int i = 0; i < N; i++)
{
    weights[i] = random.Next(1, B / 2);
    Console.Write($"{weights[i]}, ");
}
Console.WriteLine();
Console.WriteLine();

do
{

    if (IsValid())
    {
        var solutionvalue = SolutionValue();
        if (solutionvalue > bestSolutionValue)
        {
            soulutionValues.Add(solutionvalue);
            bestSolutionValue = solutionvalue;
            BestSolution = (int[])solution.Clone();
        }
    }
} while (Next());

Console.WriteLine($"Solution Value: {bestSolutionValue}, ");
for (int i = 0; i < N; i++)
{
    Console.Write($"{BestSolution[i]}, ");
}
Console.WriteLine();

soulutionValues.Sort(); Console.WriteLine();

foreach (int s in soulutionValues) { Console.WriteLine(s); }
bool Next()
{
    int bit = 0;
    while (true)
    {
        if (solution[bit] == 0)
        {
            solution[bit] = 1;
            break;
        }
        else
        {
            solution[bit] = 0;
            bit++;
            if (bit == N) { return false; }
        }
    }

    return true;
}

bool IsValid()
{
    int totalWeigh = 0;
    for (int i = 0; i < N; i++)
    {
        totalWeigh += weights[i] * solution[i];
    }

    return totalWeigh <= B;
}

int SolutionValue()
{
    int totalValue = 0;
    for (int i = 0; i < N; i++)
    {
        totalValue += values[i] * solution[i];
    }

    return totalValue;
}