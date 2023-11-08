// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
var t = new TryLinq();
var gen = t.GetFibonacci().GetEnumerator();
for (int i = 0; i < 10; i++)
{
    if (gen.MoveNext()) // Move to the next element
    {
        int v = gen.Current; // Get the current value
        Console.WriteLine(v);
    }
}
gen.Dispose();
for (int i = 0; i < 10; i++)
{
    if (gen.MoveNext()) // Move to the next element
    {
        int v = gen.Current; // Get the current value
        Console.WriteLine(v);
    }
}
class TryLinq
{
    public IEnumerable<int> GetFibonacci()
    {
        int previousVal1 = 0;
        int previousVal2 = 1;

        while (true)
        {
            int nextVal = previousVal1 + previousVal2;
            previousVal1 = previousVal2;
            previousVal2 = nextVal;
            yield return nextVal;
        }
    }

   
}

