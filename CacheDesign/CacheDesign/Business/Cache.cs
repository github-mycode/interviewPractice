using CacheDesign.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheDesign.Business
{
    public class Cache<Tkey, Tvalue> : ICache<Tkey, Tvalue>
    {
        IEvictionPolicy<Tkey> evictionPolicy;
        IStorage<Tkey, Tvalue> storage;
        public Cache(IEvictionPolicy<Tkey> e, IStorage<Tkey, Tvalue> s)
        {
            evictionPolicy = e;
            storage = s;
        }
        public void Add(Tkey key, Tvalue value)
        {
            try
            {
                storage.Add(key, value);
                evictionPolicy.KeyAccessed(key);
            }
            catch(Exception ex)
            {
                //if storage full exeption
                Tkey temp = evictionPolicy.EvictKey();
                storage.Delete(temp);
            }

        }

        public void Delete(Tkey key)
        {
            Tkey temp = evictionPolicy.EvictKey();
            storage.Delete(temp);
        }

        public Tvalue Get(Tkey key)
        {
            Tvalue value = storage.Get(key);
            evictionPolicy.KeyAccessed(key);
            return value;
        }
    }
}
