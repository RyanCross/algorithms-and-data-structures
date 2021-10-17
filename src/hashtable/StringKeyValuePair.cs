using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.src.hashtable
{
    struct StringKeyValuePair
    {
        readonly string Key;
        readonly string Value;

        public StringKeyValuePair(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public string GetKey()
        {
            return Key;
        }

        public string GetValue()
        {
            return Value;
        }
    }
}
