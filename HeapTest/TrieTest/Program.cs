using System;

namespace TrieTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Add("Priya");
            trie.Add("Pri");
            trie.Add("Priyanka");
            trie.Add("Prachi");
            trie.Add("Ishant");
            trie.Add("Guchhuu");
            trie.Add("Ishita");

            var list = trie.Get("Pr");
        }
    }
}
