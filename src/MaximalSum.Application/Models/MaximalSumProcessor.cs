using System.Numerics;

namespace MaximalSum.Application.Models
{
    public class MaximalSumProcessor<T>(string pathToFile) where T : struct, INumber<T>
    {
        public ProcessResult<T> Process()
        {
            var parser = new RowSumParser<T>(pathToFile);

            T maxSum = default;
            string maxLine = string.Empty;
            int maxRowIndex = 0;
            int wrongLinesCount = 0;
            int currentIndex = 0;
            bool found = false;

            foreach (var (displayLine, sum, isValid) in parser.ParseRows())
            {
                if (!isValid)
                    wrongLinesCount++;
                else if (!found || sum > maxSum)
                {
                    maxSum = sum;
                    maxLine = displayLine;
                    maxRowIndex = currentIndex;
                    found = true;
                }
                currentIndex++;
            }

            return new ProcessResult<T>(new MaxSumResult<T>(maxRowIndex, maxLine, maxSum), wrongLinesCount);
        }
    }
}