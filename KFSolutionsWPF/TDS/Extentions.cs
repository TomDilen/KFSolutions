using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsWPF.TDS
{
    public static class Extentions
    {

        //bron: https://stackoverflow.com/questions/489258/linqs-distinct-on-a-particular-property
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
