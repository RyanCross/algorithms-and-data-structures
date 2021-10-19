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

        public override bool Equals(object Obj)
        {
            if (Obj == null || Obj.GetType() != GetType())
                return false;
            
            StringKeyValuePair skv = (StringKeyValuePair)Obj;
            if (skv.GetKey() == GetKey() && skv.GetValue() == GetValue())
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key, Value);
        }
    }
}
