using System.Globalization;
using System.Numerics;

namespace MaximalSum.Application.Core
{
    public class RowSumParser<T>(string path) where T : struct, INumber<T>
    {
        private const string WrongMark = "(wrong elements)";

        public IEnumerable<(string displayLine, T sum, bool isValid)> ParseRows()
        {
            using var reader = new StreamReader(path, System.Text.Encoding.UTF8, true, bufferSize: 65536);
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
            ReadOnlySpan<char> span = line.AsSpan();

            while (!span.IsEmpty)
            {
                int sep = span.IndexOfAny(' ', ',');
                ReadOnlySpan<char> token = sep < 0 ? span : span[..sep];
                span = sep < 0 ? ReadOnlySpan<char>.Empty : span[(sep + 1)..];

                if (token.IsEmpty) continue;
                if (!T.TryParse(token, CultureInfo.InvariantCulture, out T number))
                    return (T.Zero, false);
                sum += number;
            }
            return (sum, true);
        }
    }
}