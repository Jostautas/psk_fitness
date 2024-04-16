namespace psk_fitness;


/// <summary>
/// Provides extension methods for mathematical operations.
/// </summary>
public static class MathExtensions
{
    /// <summary>
    /// Determines whether the value is between the specified minimum and maximum values.
    /// </summary>
    /// <typeparam name="T">The type of values to compare.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <param name="inclusive">A value indicating whether to include the minimum and maximum values.</param>
    /// <returns>True if the value is between the minimum and maximum values; otherwise, false.</returns>
    /// <remarks>
    /// For numeric types, inclusive parameter determines whether the value can be equal to the minimum or maximum values.
    /// For non-numeric types, inclusive parameter is ignored.
    /// </remarks>
    /// <exception cref="ArgumentException">Thrown when the minimum value is greater than the maximum value.</exception>
    public static bool Between<T>(this T value, T minValue, T maxValue, bool inclusive = true) where T : IComparable<T>
    {
        if (minValue.CompareTo(maxValue) > 0) {
            throw new ArgumentException("Minimum value must be less than or equal to the maximum value.");
        }

        if (inclusive) {
            return value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0;
        }
        else {
            return value.CompareTo(minValue) > 0 && value.CompareTo(maxValue) < 0;
        }
    }
}
