using System;
using System.Collections.Generic;
using System.Text;

namespace DA205E_Assignment2.GenericList
{
    public class ListManager<T> : IListManager<T>
    {
        private List<T> list;

        public int Count
        {
            get
            {
                return list.Count();
            }
        }

        public List<T> TheList
        {
            get { return list; }
        }

        public ListManager()
        {
            list = new List<T>();
        }

        public bool Add(T type)
        {
            if (type == null)
                return false;
            
            list.Add(type);
            return true;
        }

        public bool ChangeAt(T type, int index)
        {
            if (!CheckIndex(index) && type != null)
                return false;

            list[index] = type;
            return true;
        }

        public bool CheckIndex(int index)
        {
            if (index < 0 || index >= list.Count)
                return false;

            return true;
        }

        public void DeleteAll()
        {
            list = new List<T>();
        }

        public bool DeleteAt(int index)
        {
            if (!CheckIndex(index))
                return false;

            list.RemoveAt(index);
            return true;
        }

        public T GetAt(int index)
        {
            return list.ElementAt(index);
        }

        public string[] ToStringArray()
        {
            if (Count == 0)
                return Array.Empty<string>();

            string[] info = new string[Count];
            
            for (int i = 0; i < Count; i++)
            {
                info[i] = list[i].ToString();
            }

            return info;
        }

        public List<string> ToStringList()
        {
            if (Count == 0)
                return new List<string>(); // Returning an empty list of strings to avoid null checks

            List<string> info = new List<string>();

            for (int i = 0; i < Count; i++)
            {
                info.Add(list[i].ToString());
            }

            return info;
        }
    }
}
