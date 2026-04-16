using System.Numerics;

namespace MaximalSum.Application.Core;

public record MaxSumResult<T>(int RowIndex, string Row, T Sum)
    where T : struct, INumber<T>;