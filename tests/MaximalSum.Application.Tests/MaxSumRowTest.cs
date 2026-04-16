using MaximalSum.Application.Core;

namespace MaximalSum.Application.Tests;

public class GetSumOfElementsTests : IDisposable
{
    private readonly string _tempFile = Path.GetTempFileName();

    [Theory]
    [InlineData(new[] { "1 2 3", "10 20", "5" }, 1, 30)]
    [InlineData(new[] { "7 8" }, 0, 15)]
    [InlineData(new[] { "5 5", "3 7" }, 0, 10)]
    [InlineData(new[] { "-1 -2", "1 2" }, 1, 3)]
    [InlineData(new[] { "abc", "-1 -2", "-5 -6" }, 1, -3)]
    public void GetMaxSumResult_ShouldReturnCorrectRowAndSum(
        string[] lines, int expectedIndex, int expectedSum)
    {
        // Arrange
        File.WriteAllLines(_tempFile, lines);
        var processor = new MaximalSumProcessor<int>(_tempFile);

        // Act
        ProcessResult<int> result = processor.Process();

        // Assert
        Assert.Equal(expectedIndex, result.MaxSum.RowIndex);
        Assert.Equal(expectedSum, result.MaxSum.Sum);
    }

    public void Dispose() => File.Delete(_tempFile);
}