using System;
using System.Collections.Generic;
using System.Text;

/**
  * Hash Table Overview:
  * What: An unordered collection of unique key value pairs, stored internally as an array.
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
        
        /**
         * Inserts key value pair into hash table's underlying array, the key must not already exist in the hashtable. 
         * Collisions are handled via chaining.
         */
        public void Insert(StringKeyValuePair kv)
        {
            //enforce non-null, unique kvp
            if (ContainsKey(kv.GetKey()))
                throw new ArgumentException("Key is null or already exists in Hashtable. A key must be unique.");

            ulong idxOfKey = GetKeyIndex(kv.GetKey());

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

        /**
         * Returns true if key was successfully found and removed, false otherwise.
         */
        public bool Delete(string key)
        {
            if (!ContainsKey(key))
                return false;

            ulong keyIdx = GetKeyIndex(key);
            foreach (StringKeyValuePair kvp in hashTableArray[keyIdx])
            {
                if (kvp.GetKey() == key)
                {
                    hashTableArray[keyIdx].Remove(new StringKeyValuePair(kvp.GetKey(), kvp.GetValue()));  
                    return true;
                }
            }

            if (hashTableArray[keyIdx].Count == 0)
                hashTableArray[keyIdx] = null; // set back to null, so that insert logic does not count new insertions here as collisions, technically if we added a check around numCollisions to check for empty list when list not null then this might not be needed
                

            return false;
        }

        /**
         * Returns true if key was found in Hashtable, false otherwise.
         */
        bool ContainsKey(string key)
        {
            if(key == null)
                throw new ArgumentNullException("key", "Provided key cannot be null.");

            ulong keyIdx = GetKeyIndex(key);

            if (hashTableArray[keyIdx] != null)
            {
                foreach(StringKeyValuePair kvp in hashTableArray[keyIdx])
                {
                    if (kvp.GetKey() == key)
                        return true;
                }
            }

            return false;
        }

        /**
         * Returns true if the Hashtable contains the specified Key-Value pair, false otherwise.
         *
         **/
        bool Contains(StringKeyValuePair kvp)
        {
            if (object.ReferenceEquals(null, kvp))
                throw new ArgumentNullException();

            ulong keyIdx = GetKeyIndex(kvp.GetKey());
            if (hashTableArray[keyIdx].Count > 0 && hashTableArray[keyIdx].Find(kvp) != null)
            {
                return true;//TODO test if find will work with two value equivalent objs, with or without the hashcode/equals overrides in kvp
            }

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

        /**
         * Returns the idx of the key after it has been hashed.
         */
        private ulong GetKeyIndex(string key)
        {
            if (key == null)
                throw new ArgumentNullException();
            else return Hash(key) % (ulong)Size;
        }
    }
}
