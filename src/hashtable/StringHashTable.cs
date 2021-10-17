using System;
using System.Collections.Generic;
using System.Text;

/**
  * Hash Table Overview:
  * What: A Collection of key value pairs, stored internally as an array.
  * The indexing of the elements to be stored are determined by a hash function upon insertion
  * 
  * Provide O(1) insert, delete and search operations
  * 
  * 
  * On Sizing:
  * A good general “rule of thumb” is:
  * The hash table should be an array with length about 1.3 times the maximum number of keys that will actually be in the table, and
  * Size of hash table array should be a prime number. Heuristic for resizing: somewhere between 55%-70% capacity filled
  */

// Useful side note: you can always use mod(n) where n is length of array to get an index within array lengthless than array size

namespace AlgorithmsAndDataStructures.src.hashtable
{
    /**
     * Simple hashtable implementation with String as type Key/Value pair, with chaining to resolve collisions.
     */
    class StringHashTable
    {
        readonly int Size;
        int numCollisions = 0; // for science
        private LinkedList<StringKeyValuePair>[] hashTableArray;

        public int NumCollisions { get => numCollisions; set => numCollisions = value; }

        public StringHashTable(int size)
        {
            Size = size;
            hashTableArray = new LinkedList<StringKeyValuePair>[Size];
        }
        
        public void Insert(StringKeyValuePair kv)
        {
            ulong idxOfKey = Hash(kv.GetKey()) % (ulong)Size;

            //chaining: append element to front of list when a collision occurs
            if (hashTableArray[idxOfKey] != null)
            { // collision found, prepend new element to list
                hashTableArray[idxOfKey].AddFirst(kv);
                numCollisions++;
            }
            else
            {
                hashTableArray[idxOfKey] = new LinkedList<StringKeyValuePair>();
                hashTableArray[idxOfKey].AddFirst(kv);
            }
        }

        StringKeyValuePair Search()
        {
            return new StringKeyValuePair("Implement", "Me");
        }

        void Delete()
        {
            //TODO
        }

        bool ContainsKey(string key)
        {
            return false;
        }

        /**
         * https://softwareengineering.stackexchange.com/questions/49550/which-hashing-algorithm-is-best-for-uniqueness-and-speed
         * This is an impl of djb hash
         */
        private ulong Hash(string str)
        {
            ulong hash = 5381;
            uint i;

            for (i=0; i < str.Length; i++)
            {
                hash = ((hash << 5) + hash + ((byte)str[(int)i])); // figure out wtf this actually does, something about bit shifting // probably need to understand bits and bit manipulation
            }

            return hash;
        }
    }
}
