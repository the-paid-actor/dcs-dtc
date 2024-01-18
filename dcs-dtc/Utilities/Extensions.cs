
namespace DTC.Utilities.Extensions;

public static class Extension
{
    public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest)
    {
        first = list.Count > 0 ? list[0] : default(T); // or throw
        rest = list.Skip(1).ToList();
    }

    public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest)
    {
        first = list.Count > 0 ? list[0] : default(T); // or throw
        second = list.Count > 1 ? list[1] : default(T); // or throw
        rest = list.Skip(2).ToList();
    }

    public static bool InBounds<T>(this IList<T> list, int index)
    {
        return index >= 0 && index < list.Count;
    }

    public static void InsertBefore<T>(this IList<T> list, T itemToInsert, T itemBefore)
    {
        var idx = list.IndexOf(itemBefore);
        if (idx == -1)
        {
            throw new ArgumentException("Item not found in list");
        }
        list.Insert(idx, itemToInsert);
    }

    public static void InsertAfter<T>(this IList<T> list, T itemToInsert, T itemBefore)
    {
        var idx = list.IndexOf(itemBefore);
        if (idx == -1)
        {
            throw new ArgumentException("Item not found in list");
        }
        list.Insert(idx + 1, itemToInsert);
    }
}
