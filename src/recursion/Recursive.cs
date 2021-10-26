using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.src.recursion
{
    class Recursive
    {
        /**
         * Recursive implementation of a power function (raising x to the yth power)
         * This is also how permutations with repitition are calculated
         */
        public static int Pow(int n, int count)
        {
            if (count == 1)
                return n;
            return n * Pow(n, count - 1);
        }
    }
}
