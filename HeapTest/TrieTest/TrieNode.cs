using System;
using System.Collections.Generic;
using System.Text;

namespace TrieTest
{
    public class TrieNode
    {
        public bool EndOfWord;
        public Dictionary<char, TrieNode> children;

        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
            EndOfWord = false;
        }
    }
}
