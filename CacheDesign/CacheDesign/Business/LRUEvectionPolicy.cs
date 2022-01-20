using CacheDesign.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CacheDesign.Business
{
    public class LRUEvectionPolicy<Tkey> : IEvictionPolicy<Tkey>
    {
        private LinkedList<Tkey> dll;
        private Dictionary<Tkey, LinkedListNode<Tkey>> map;

        public LRUEvectionPolicy()
        {
            dll = new LinkedList<Tkey>();
            map = new Dictionary<Tkey, LinkedListNode<Tkey>>();
        }
        public Tkey EvictKey()
        {
            Tkey key = dll.First.Value;
            dll.RemoveFirst();
            map.Remove(key);
            return key;
        }

        public void KeyAccessed(Tkey key)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                dll.Remove(node);
                dll.AddLast(node);
            }
            else
            {
                LinkedListNode<Tkey> node = new LinkedListNode<Tkey>(key);
                map.Add(key, node);
                dll.AddLast(node);
            }
        }
    }
}
