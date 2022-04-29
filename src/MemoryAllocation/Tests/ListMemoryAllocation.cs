using BenchmarkDotNet.Attributes;

namespace MemoryAllocation.Tests;

[MemoryDiagnoser]
public class ListMemoryAllocation
{
    public List<int> Targets => new List<int> { 10, 100, 1000 };

    [ParamsSource(nameof(Targets))]
    public int Length { get; set; }

    [Benchmark]
    public void ArrayDynamicLength()
    {
        int[] values = new int[1];

        for (int i = 0; i < Length; i++)
        {
            values[i] = i;
            Array.Resize(ref values, Length);
        }
    }

    [Benchmark]
    public void ArrayFixedLength()
    {
        int[] values = new int[Length];

        for (int i = 0; i < Length; i++)
        {
            values[i] = i;
        }
    }

    [Benchmark]
    public void ListDynamicLength()
    {
        List<int> values = new List<int>();

        for (int i = 0; i < Length; i++)
        {
            values.Add(i);
        }
    }

    [Benchmark]
    public void ListFixedLength()
    {
        List<int> values = new List<int>(Length);

        for (int i = 0; i < Length; i++)
        {
            values.Add(i);
        }
    }
}
