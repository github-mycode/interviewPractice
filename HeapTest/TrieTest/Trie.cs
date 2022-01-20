using System;
using System.Collections.Generic;
using System.Text;

namespace TrieTest
{
    public class Trie
    {
        public TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }
        public void Add(string str)
        {
            TrieNode node = root;
            for(int i =0; i< str.Length; i++)
            {
                if (node.children.ContainsKey(str[i]))
                {
                    node = node.children[str[i]];
                }
                else
                {
                    TrieNode temp = new TrieNode();
                    node.children.Add(str[i], temp);
                    node = temp;
                }
            }
            node.EndOfWord = true;
        }

        public void Remove(string str)
        {
            RemoveUtil(str, root);
        }

        public void RemoveUtil(string str, TrieNode node)
        {
            Stack<TrieNode> s = new Stack<TrieNode>();
            int i = 0;
            while(i < str.Length)
            {
                if (node.children.ContainsKey(str[i]))
                {
                    s.Push(node.children[str[i]]);
                    i++;
                    node = node.children[str[i]];
                }
                else
                {
                    break;
                }
            }
            if(str.Length == i && s.Peek().EndOfWord)
            {
                if (s.Peek().children.Count > 0)
                {
                    s.Pop().EndOfWord = false;

                }
                else
                {
                    while(s.Peek().children.Count == 1)
                    {
                        s.Pop().children = new Dictionary<char, TrieNode>();
                    }
                }
            }
        }

        public List<string> Get(string pre)
        {
            List<string> list = new List<string>();
            TrieNode node = root;
            for(int  i=0; i< pre.Length; i++)
            {
                if (node.children.ContainsKey(pre[i])){
                    node = node.children[pre[i]];
                }
                else
                {
                    return null;
                }
            }
            GetWords(list, node, pre);
            return list;
        }

        private void GetWords(List<string> list, TrieNode node, string w)
        {
            if(node == null)
            {
                return;
            }
            if (node.EndOfWord)
            {
                list.Add(w);
            }
            foreach(char c in node.children.Keys)
            {
                GetWords(list, node.children[c], w + c);
            }
        }
    }

}
