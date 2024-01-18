
namespace DTC.Utilities.Extensions;

public static class ToolStripExtensions
{
    /// <summary>
    /// Automatically show/hide separator in toolstrips (Menus, toolbars, etc).
    /// This will hide / show separators based on the other toolstripitems in the collections.
    /// A separator will be hidden if it would be the first visible entry in the list.
    /// A separator will be hidden if it would be the last visible entry in the list.
    /// A separator will be hidden if it would appear right after another separator.
    /// All other separatos will be shown.
    /// </summary>
    /// <param name="items">A collection of ToolStripItems</param>
    /// <param name="includeSubmenus">If true, also cleanup separators in submenus</param>
    public static void CleanUpSeparators(this ToolStripItemCollection items, bool includeSubmenus = true)
    {
        // Will be true when we have last seen a visible item 
        // which is not a separator 
        bool canInsertSeparator = false;

        List<ToolStripSeparator> keepers = new List<ToolStripSeparator>();
        List<ToolStripSeparator> gonners = new List<ToolStripSeparator>();

        ToolStripSeparator lastSeparator = null;

        // Decide which separators should stay and which should go
        for (int i = 0; i < items.Count; i++)
        {
            ToolStripItem item = items[i];

            if (item is ToolStripSeparator)
            {
                if (canInsertSeparator)
                {
                    keepers.Add(item as ToolStripSeparator);
                    lastSeparator = item as ToolStripSeparator;
                    canInsertSeparator = false;
                }
                else
                {
                    gonners.Add(item as ToolStripSeparator);
                }
            }
            else
            {
                // After seeing at least one visible item, we can add a new separator again
                if (item.Available)
                {
                    canInsertSeparator = true;
                }
            }

            // Recursion
            if (includeSubmenus && item is ToolStripDropDownItem)
            {
                (item as ToolStripDropDownItem).DropDownItems.CleanUpSeparators(true);
            }
        }

        if (!canInsertSeparator && lastSeparator != null)
        {
            // The last separator has no following visible other entries, 
            // so we don't want it
            gonners.Add(lastSeparator);
        }

        // Show and hide the separators
        // First show, then hide, because it is possible
        // a separator at the end of the menu is in both lists
        // and it should be hidden
        foreach (var separator in keepers)
        {
            separator.Visible = true;
        }
        foreach (var separator in gonners)
        {
            separator.Visible = false;
        }
    }
}
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
