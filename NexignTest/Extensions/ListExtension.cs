using System.Collections.Generic;

namespace NexignTest.Extensions
{
    public static class ListExtension
    {
        public static T AddItem<T>(this List<T> list, T item)
        {
            list.Add(item);
            return item;
        }
    }
}
