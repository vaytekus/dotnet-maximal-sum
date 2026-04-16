using BenchmarkDotNet.Attributes;
using MaximalSum.Application.Core;

namespace BenchmarkDotNet.Application;

[MemoryDiagnoser(displayGenColumns: true)]
public class MaximalSumBenchmarks
{
    private const string DataFile = "generated-data.txt";
    private const int TargetSizeBytes = 1024 * 1024; // 1 MB

    [GlobalSetup]
    public void Setup()
    {
        if (File.Exists(DataFile) && new FileInfo(DataFile).Length >= TargetSizeBytes)
            return;

        var rng = new Random(42);
        using var writer = new StreamWriter(DataFile);
        long written = 0;
        while (written < TargetSizeBytes)
        {
            var line = string.Join(" ", Enumerable.Range(0, 50).Select(_ => rng.Next(-9999, 9999)));
            writer.WriteLine(line);
            written += line.Length + Environment.NewLine.Length;
        }
    }

    [Benchmark]
    public object Process_1MB()
    {
        var processor = new MaximalSumProcessor<int>(DataFile);
        return processor.Process();
    }
}