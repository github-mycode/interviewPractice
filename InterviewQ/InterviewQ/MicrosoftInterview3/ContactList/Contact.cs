using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQ.MicrosoftInterview3.ContactList
{
    public class Contact
    {
        public string name { get; set; }
        public string number { get; set; }
        public string email { get; set; }

        public static List<Contact> contactList = new List<Contact>();

        public static Trie dictionary = new Trie(); 
        public static Dictionary<string,List<Contact>> map = new Dictionary<string, List<Contact>>();
        public Contact(string n, string num, string e)
        {
            name = n;
            number = num;
            email = e;
        }

        public List<Contact> AddContact(Contact c)
        {
            AddWord(c.name, c);
            AddWord(c.number, c);
            AddWord(c.email, c);
            contactList.Add(c);
            return contactList;
        }

        public  void AddWord(string word, Contact c)
        {
            if (map.ContainsKey(word))
            {
                map[word].Add(c);
            }
            else
            {
                map.Add(word, new List<Contact>() { c });
                dictionary.AddWord(word);
            }
        }
        public static List<Contact> GetContactListStartWith(string c)
        {
            List<string> list = dictionary.GetWordForPrefix(c);
            List<Contact> contacts = new List<Contact>();
            if(list != null)
            {
                foreach (string l in list)
                {
                    List<Contact> tempList = map[l];
                    if(tempList != null)
                    {
                        foreach (Contact contact in tempList)
                        {
                            if (!contacts.Any(x => x == contact))
                            {
                                contacts.Add(contact);
                            }
                        }
                    }
                }
            }
            return contacts;
        }

        public static void TestContact()
        {
            Contact c1 = new Contact("Priya", "9034438874", "priya@gmail.com");
            Contact c2 = new Contact("Prachi", "8023933542", "prachi@gmail.com");
            Contact c3 = new Contact("Ishant", "986805453", "ishant@gmail.com");
            Contact c4 = new Contact("Priyanka", "9134438874", "priyanka@gmail.com");

            List<Contact> list = c1.AddContact(c1);
            list = c2.AddContact(c2);
            list = c3.AddContact(c3);
            list = c4.AddContact(c4);
            var data = GetContactListStartWith("Prasd");
        }
    }
}
