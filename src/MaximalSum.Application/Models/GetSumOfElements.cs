using System.Numerics;

namespace MaximalSum.Application.Models
{
    public class GetSumOfElements<T>(IReadOnlyList<string> lines, IReadOnlyList<T> sums, IReadOnlyList<bool> isValid)
        where T : struct, INumber<T>
    {
        public MaxSumResult<T> GetMaxSumResult()
        {
            T maxSum = default;
            int maxRowIndex = 0;
            bool found = false;

            for (int i = 0; i < sums.Count; i++)
            {
                if (!isValid[i]) continue;

                if (!found || maxSum < sums[i])
                {
                    maxRowIndex = i;
                    maxSum = sums[i];
                    found = true;
                }
            }

            return new MaxSumResult<T>(maxRowIndex, lines[maxRowIndex], maxSum);
        }
    }
}