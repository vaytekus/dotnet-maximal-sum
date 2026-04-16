using System.Numerics;

namespace MaximalSum.Application.Core;

public record ProcessResult<T>(MaxSumResult<T> MaxSum, int WrongLinesCount)
    where T : struct, INumber<T>;