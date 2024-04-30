using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public static class Extensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (T item in items) 
            {
                if(predicate(item))
                    yield return item;
            }
        }

        public static int MyCount<T>(this IEnumerable<T> items)//, Func<T, bool> predicate)
        {
            int counter = 0;

            foreach (T item in items) 
            {
                //if (predicate(item))
                    counter++;
            }

            return counter;
        }

        public static IEnumerable<TResult> Choose<Tsource, TResult>(this IEnumerable<Tsource> items, Func<Tsource, TResult> selector)
        {
            foreach (Tsource item in items) 
            {
                yield return selector(item);
            }
        }
    }
}
