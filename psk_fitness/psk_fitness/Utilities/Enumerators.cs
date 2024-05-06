namespace psk_fitness.Utilities;

public static class Enumerators
{
    public static IEnumerable<(int index, T item)> WithIndex<T>(this IEnumerable<T> source)
    {
        return source.Select((item, index) => (index, item));
    }
}
