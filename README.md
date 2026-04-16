# dotnet-maximal-sum

Console app that reads a file with rows of numbers and finds the row with the maximum sum. Invalid rows are marked automatically.

## Stack

- .NET 8 / C#
- BenchmarkDotNet
- xUnit

## Run

```bash
dotnet run --project src/MaximalSum.Application
```

## Tests

```bash
dotnet test
```

## Benchmark

```bash
dotnet run --project src/BenchmarkDotNet.Application -c Release
```