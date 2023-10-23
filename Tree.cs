using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    class Tree<T> : IList<T>
    {
        private List<T> members = new List<T>(); // store all people
        private Dictionary<T, List<T>> relation = new Dictionary<T, List<T>>(); //relation between parents and son
        
        public void AddChild(T child, T dad, T mom) // add child for parents
        {
            Add(child); // add to members
            if (!relation.ContainsKey(dad) || !relation.ContainsKey(mom)) 
            { // if parents does not exist, create key and list of childs as a value
                relation.Add(dad, new List<T>()); // 1st variant
                relation[mom] = new List<T>(); // 2nd variant
            }                
            relation[dad].Add(child); // add child to the list (value)
            relation[mom].Add(child);
            
        }
        public void PrintDescendants(Member parent) // printing family tree relations
        {
            var query = relation.Where(key => parent.Equals(key.Key)).Select(key => key.Value); // query for finding a parents
            Console.WriteLine(parent.FullName);
            foreach (dynamic findParent in query) // from particular parent find value (list of children)
            {
                foreach (Member child in findParent) // find value from list
                {
                    Console.WriteLine(" ~" + child.FullName); 
                    var query1 = relation.Where(key => child.Equals(key.Key)).Select(key => key.Value); // from founded child find themselvs possible childs
                    foreach (dynamic grandChilds in query1) // the same action
                    {
                        foreach (Member grandchild in grandChilds)
                        {
                            Console.WriteLine("    ~" + grandchild.FullName);
                        }
                    }
                }
            }
        }
        #region Realization of IList interface
        public T this[int index] { get => members[index]; set => (members[index]) = value; }
        public bool IsReadOnly => false;
        public bool IsFixedSize => false;
        public int Count => members.Count;
        public object SyncRoot => null;
        public bool IsSynchronized => false;
        public void Add(T value)
        {
            if (!Contains(value))
            {
                members.Add(value);
            }
        }
        public void Clear()
        {
            members.Clear();
        }
        public bool Contains(T value)
        {
            return members.Contains(value);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            members.CopyTo(array, arrayIndex);
        }
        public IEnumerator GetEnumerator()
        {
            return members.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            if (Contains(item))
            {
               return members.IndexOf(item);
            }
            else
            {
                return -1;
            }
        }
        public void Insert(int index, T item)
        {
            T[] newList = new T[members.Count+1];
            for (int i = 0; i < index; i++)
            {
                newList[i] = members[i];
            }
            newList[index] = item;
            for (int i = index+1; i < newList.Length; i++)
            {
                newList[i] = members[i-1];
            }
            members = newList.ToList();
        }
        public bool Remove(T item)
        {
            return members.Remove(item);
        }
        public void RemoveAt(int index)
        {
            Remove(members[index]);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return members.GetEnumerator();
        }
        #endregion
    }
}
