using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TriangleApi.Contracts;

namespace TriangleApi.Util
{
    public static class Extensions
    {
        /// <summary>
        /// To Generate First Alphabet "A" pass startSequence = ""
        /// </summary>
        /// <param name="startSequence"></param>
        /// <returns></returns>
        public static string GetNextAlphabet(this string startSequence)
        {

            int i = startSequence.Length - 1;
            if (i >= 0 && startSequence[i] == 'Z')
            {
                startSequence = "".PadRight(i + 2, 'A');
                return startSequence;
            }
            if (i == -1)
                startSequence = "A";
            else
            {
                char sequence = startSequence[i];
                sequence = ++sequence;

                startSequence = startSequence.Remove(startSequence.LastIndexOf(startSequence[i]), 1).Insert(i, sequence.ToString());
            }

            return startSequence;
        }

        public static ConcurrentDictionary<string, ITriangle> ConvertToKeyValuePair(this IEnumerable<IPolygon> collection)
        {
            ConcurrentDictionary<string, ITriangle> keyValuePairs = new ConcurrentDictionary<string, ITriangle>();

            foreach (ITriangle item in collection)
            {
                keyValuePairs.TryAdd(item.Label, item);
                keyValuePairs.TryAdd(item.GetHashCode().ToString(), item);
            }


            return keyValuePairs;
        }

        public static bool IsNumber(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return false;

            return value.All(Char.IsDigit);

        }


    }
}