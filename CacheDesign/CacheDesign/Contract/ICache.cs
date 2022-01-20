using System;
using System.Collections.Generic;
using System.Text;

namespace CacheDesign.Contract
{
    interface ICache<Tkey, Tvalue>
    {
        public void Add(Tkey key, Tvalue value);
        public Tvalue Get(Tkey key);
        public void Delete(Tkey key);
    }
}
