using CacheDesign.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheDesign.Business
{
    public class HashmapStorage<Tkey, Tvalue> : IStorage<Tkey, Tvalue>
    {
        public int capacity { get; set; }
        Dictionary<Tkey, Tvalue> storage;
        public HashmapStorage(int c)
        {
            capacity = c;
            storage = new Dictionary<Tkey, Tvalue>();
        }
        public void Add(Tkey key, Tvalue value)
        {
            if (storage.ContainsKey(key))
            {
                //Key already exist
            }
            else
            {
                storage.Add(key, value);
            }
        }

        public void Delete(Tkey key)
        {
            if (storage.ContainsKey(key))
            {
                storage.Remove(key);
            }
            else
            {
                //Key has been removed
            }
        }

        public Tvalue Get(Tkey key)
        {
            if (storage.ContainsKey(key))
            {
                return storage[key];
            }
            else
            {
                // key dose not exist
                return default(Tvalue);
            }
        }
    }
}
