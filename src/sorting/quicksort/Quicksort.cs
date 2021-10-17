using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.src.sorting.quicksort
{
    /**
     * Simplest Quicksort impl, where pivot chosen is always the last element
     * Based off the notion that a single element array is always sorted
     */
    class Quicksort
    {
        // TODO investigate other pivot picking methods
        public static void DoQuickSort(int[] arr)
        {
            Quicksort.Sort(0, arr.Length - 1, arr);
        }

        public static void Sort(int L, int R, int[] arr)
        {
            int pivotIdx;
            if (L >= R)
                return;
            pivotIdx = Quicksort.Partition(L, R, arr); // arr[pivot] will be in the correct position after this call

            Sort(L, pivotIdx - 1, arr);
            Sort(pivotIdx + 1, R, arr);

        }

        /**
         * Partitions the array based on the selected pivot, elements with a val < pivot are moved to the left of the pivot in the arr, because each element is iterated on, the elements
         * greater than pivot will end up on the right. The completion of this method will result in pivot being in its correct position.
         */
        public static int Partition(int L, int R, int[] arr) //sorting the pivot into the correct position on subsets of the array until everything is sorted
        {
            int pivot = arr[R];
            int i = L - 1;

            for (int j = L; j < R; j++) //need to start this at L, which on first call will be zero, but on subsequent calls will be the start of the section of the array being partitioned
            {
                if (arr[j] < pivot)
                {        
                    i += 1;
                    int hold = arr[i];
                    arr[i] = arr[j];
                    arr[j] = hold;
                }
            }

            // swap pivot with arr[i + 1], as thats where it belongs,
            int hold2 = arr[i + 1];
            arr[i + 1] = arr[R];
            arr[R] = hold2;

            // return index of the pivot
            return i + 1;

        }
    }
}
