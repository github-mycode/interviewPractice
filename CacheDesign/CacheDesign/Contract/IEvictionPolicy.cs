using System;
using System.Collections.Generic;
using System.Text;

namespace CacheDesign.Contract
{
    public interface IEvictionPolicy<Tkey>
    {
        public void KeyAccessed(Tkey key);
        public Tkey EvictKey();

    }
}
