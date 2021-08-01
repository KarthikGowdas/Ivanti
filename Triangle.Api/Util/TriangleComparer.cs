using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TriangleApi.Contracts;

namespace TriangleApi.Util
{
    public class TriangleComparer : IComparer<ITriangle>
    {
        public int Compare(ITriangle c1, ITriangle c2)
        {

            if (c1 == null && c2 == null)
            {
                return 0;
            }

            if (c1.Equals(c2))
            {
                return 0;
            }
            else
            {
                string[] c1Label = SplitLabel(c1.Label);
                string[] c2Label = SplitLabel(c2.Label);

                int alphabetComparision = AlphabetComparission(c1Label.FirstOrDefault(), c2Label.FirstOrDefault());

                if (alphabetComparision == 0)
                {
                    int c1Number = 0;
                    int c2Number = 0;

                    Int32.TryParse(c1Label.Skip(1).FirstOrDefault(), out c1Number);
                    Int32.TryParse(c2Label.Skip(1).FirstOrDefault(), out c2Number);

                    return c1Number.CompareTo(c2Number);
                }
                else
                {
                    return alphabetComparision;
                }

                
            }

        }

        private int AlphabetComparission(string s1, string s2)
        {
            if(s1.Length == s2.Length)
            {
                return string.Compare(s1, s2);
            }
            else if(s1.Length > s2.Length)
            {
                return 1;
            }
            return -1;
        }

        private string[] SplitLabel(string label)
        {
           return Regex.Split(label, @"(?<=[a-zA-Z])(?=\d)");
        }
    }
}