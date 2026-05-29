# dotnet-maximal-sum

Console app that reads a file with rows of numbers and finds the row with the maximum sum.

## Stack

- .NET 8 / C#
- xUnit
- BenchmarkDotNet

## Run

```bash
dotnet run --project src/MaximalSum.Application
```

Enter a file name when prompted — the app looks for it in your Documents folder.

## Test

```bash
dotnet test
```

## Benchmark

```bash
dotnet run -c Release --project src/BenchmarkDotNet.Application
```