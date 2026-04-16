using System.Globalization;
using System.Numerics;

namespace MaximalSum.Application.Models
{
    public class RowSumParser<T>(string path) where T : struct, INumber<T>
    {
        private const string WrongMark = "(wrong elements)";

        public IEnumerable<(string displayLine, T sum, bool isValid)> ParseRows()
        {
            using var reader = new StreamReader(path);
            string? raw;
            while ((raw = reader.ReadLine()) != null)
            {
                var (sum, isValid) = ParseLine(raw);
                yield return (isValid ? raw : $"{WrongMark} {raw}", sum, isValid);
            }
        }

        private static (T sum, bool isValid) ParseLine(string line)
        {
            var sum = T.Zero;
            foreach (string token in line.Split([',', ' '], StringSplitOptions.RemoveEmptyEntries))
            {
                if (!T.TryParse(token, CultureInfo.InvariantCulture, out T number))
                    return (T.Zero, false);
                sum += number;
            }
            return (sum, true);
        }
    }
}