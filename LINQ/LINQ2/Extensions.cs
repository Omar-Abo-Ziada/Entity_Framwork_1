namespace LINQ2
{
    internal static class Extensions
    {


        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<MiniCourse> GetMini(this IEnumerable<Course> courses, Func<Course, MiniCourse> selector)
        {
            foreach (var crs in courses)
            {
                yield return selector(crs);
            }
        }

        public static IEnumerable<TResult> Choose<TSource, TResult>(this IEnumerable<TSource> courses, Func<TSource, TResult> selector)
        {
            foreach (var crs in courses)
            {
                yield return selector(crs);
            }
        }
    }
}
