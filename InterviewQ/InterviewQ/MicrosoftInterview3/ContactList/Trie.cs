using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQ.MicrosoftInterview3
{
    public class Trie
    {
        public bool EndOfWord;
        public Dictionary<char, Trie> Child;
        public static Trie root = new Trie();
        public Trie()
        {
            EndOfWord = false;
            Child = new Dictionary<char, Trie>();
        }

        public static void TrieTest()
        {
            Trie t = new Trie();
            t.AddWord("Priya");
            t.AddWord("Prachi");
            t.AddWord("Ishant");
            t.AddWord("Ishita");
            t.AddWord("Is");
            t.AddWord("IshantGupta");
            t.AddWord("IshitaPagala");
            var data = t.GetAllWords(Trie.root, null, "");
            var d1 = t.GetWordForPrefix("Is");
        }



        public void AddWord(string s)
        {
            Trie node = root;
            foreach(char c in s)
            {
                if (node.Child.ContainsKey(c))
                {
                    node = node.Child[c];
                }
                else
                {

                    Trie tempNode = new Trie();
                    node.Child.Add(c, tempNode);
                    node = tempNode;
                }
            }
            node.EndOfWord = true;

        }
        List<string> list = new List<string>();
        public List<string> GetAllWords(Trie node, char? c, string s)
        {
            list = new List<string>();
            GetAllWords_Util(node, c, s);
            return list;
        }
        public void GetAllWords_Util(Trie node, char? c, string s)
        {
            if(node == null)
            {
                return;
            }
            if(c != null)
            {
                s += c;
            }
            if (node.EndOfWord)
            {
                list.Add(s);
            }
            foreach(var key in node.Child.Keys)
            {
                GetAllWords_Util(node.Child[key], key, s);
            }
        }

        public List<string> GetWordForPrefix(string pr)
        {
            List<string> ls;
            Trie node = root;
            for(int i = 0; i< pr.Length; i++)
            {
                if (node.Child.ContainsKey(pr[i]))
                {
                    node = node.Child[pr[i]];
                }
                else
                {
                    return null;
                }
            }
            ls = GetAllWords(node, null, "");
            for(int i = 0; i< ls.Count; i++)
            {
                ls[i] = pr + ls[i];

            }
            return ls;
        }
    }
}
