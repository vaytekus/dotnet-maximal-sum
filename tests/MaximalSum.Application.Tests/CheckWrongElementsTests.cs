using MaximalSum.Application.Core;

namespace MaximalSum.Application.Tests;

public class CheckWrongElementsTests : IDisposable
{
    private readonly string _tempFile = Path.GetTempFileName();

    public void Dispose() => File.Delete(_tempFile);

    private List<(string displayLine, int sum, bool isValid)> ParseLines(params string[] lines)
    {
        File.WriteAllLines(_tempFile, lines);
        return new RowSumParser<int>(_tempFile).ParseRows().ToList();
    }

    [Fact]
    public void ParseRows_ShouldMarkLineWithInvalidToken()
    {
        var rows = ParseLines("1 2 3", "1 abc 3", "4 5");

        Assert.Contains("(wrong elements)", rows[1].displayLine);
        Assert.DoesNotContain("(wrong elements)", rows[0].displayLine);
        Assert.DoesNotContain("(wrong elements)", rows[2].displayLine);
    }

    [Fact]
    public void ParseRows_ShouldReturnCorrectInvalidCount()
    {
        var rows = ParseLines("1 2", "abc", "3 xyz 4");

        Assert.Equal(2, rows.Count(r => !r.isValid));
    }

    [Fact]
    public void ParseRows_AllValid_ShouldNotMarkAnyLine()
    {
        var rows = ParseLines("1 2 3", "10 20", "5");

        Assert.Equal(0, rows.Count(r => !r.isValid));
    }

    [Fact]
    public void ParseRows_AllInvalid_ShouldMarkAllLines()
    {
        var rows = ParseLines("abc", "x y z");

        Assert.Equal(2, rows.Count(r => !r.isValid));
    }
}
