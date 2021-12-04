using System;
using System.Collections.Generic;
using System.Linq;

namespace Xpymb.TestExercises.GameRepository.Configuration.AutoMapper
{
    public static class DataExtensions
    {
        public static IEnumerable<T> ToEnumCollection<T>(this string str) where T : Enum
        {
            return str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => (T)Enum.Parse(typeof(T), s)).ToList<T>();
        }

        public static string EnumCollectionToString<T>(this IEnumerable<T> collection) where T : Enum
        {
            return string.Join(",", collection);
        }
    }
}