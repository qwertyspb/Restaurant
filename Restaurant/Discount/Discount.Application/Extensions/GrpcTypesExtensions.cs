using Google.Protobuf.WellKnownTypes;

namespace Discount.Application.Extensions;

public static class GrpcTypesExtensions
{
    public static Timestamp ToTimestamp(this DateTime date)
        => Timestamp.FromDateTime(date.ToUniversalTime());
}