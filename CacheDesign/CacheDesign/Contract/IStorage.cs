using System;
using System.Collections.Generic;
using System.Text;

namespace CacheDesign.Contract
{
    public interface IStorage<Tkey, Tvalue>
    {
        public Tvalue Get(Tkey key);
        public void Add(Tkey key, Tvalue value);
        public void Delete(Tkey key);
    }
}
