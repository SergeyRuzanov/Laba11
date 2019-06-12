using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba11
{
    public class MySortedDictionary<K, T> : IEnumerable, IEnumerator
        where K : IComparable

    {
        private int indexNow = -1;
        public MySortedDictionary()
        {
            Capacity = 8;
            Count = 0;
            Keys = new List<K>(Capacity);
            Values = new List<T>(Capacity);
        }

        public MySortedDictionary(int capacity)
        {
            Capacity = capacity;
            Count = 0;
            Keys = new List<K>(Capacity);
            Values = new List<T>(Capacity);
        }

        public MySortedDictionary(MySortedDictionary<K, T> mySortedDictionary)
        {
            Capacity = mySortedDictionary.Capacity;
            Count = mySortedDictionary.Count;
            Keys = mySortedDictionary.Keys;
            Values = mySortedDictionary.Values;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Count; i++)
            {
                str += $"{Keys[i]}: {Values[i]}\n";
            }
            return str;
        }

        public int Capacity { get; private set; }
        public int Count { get; private set; }
        public List<K> Keys { get; private set; }
        public List<T> Values { get; private set; }

        protected void Sort()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = Count - 1; j >= i + 1; j--)
                {
                    int k = Keys[j].CompareTo(Keys[j - 1]);
                    if (k < 0)
                    {
                        K t = Keys[j - 1];
                        Keys[j - 1] = Keys[j];
                        Keys[j] = t;

                        T v = Values[j - 1];
                        Values[j - 1] = Values[j];
                        Values[j] = v;
                    }
                }
            }
        }

        public bool ContainsKey(K key)
        {
            return Keys.Contains(key);
        }

        public bool ContainsValue(T value)
        {
            return Values.Contains(value);
        }

        public T GetByIndex(int index)
        {
            if (index >= 0 && index < Count)
            {
                return Values[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public K GetKey(int index)
        {
            if (index >= 0 && index < Count)
            {
                return Keys[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOfKey(K key)
        {
            return Keys.IndexOf(key);
        }

        public int IndexOfValue(T value)
        {
            return Values.IndexOf(value);
        }

        public void SetByIndex(int index, T value)
        {
            if (index >= 0 && index < Count)
            {
                Values[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(K key, T value)
        {
            if (Count < Capacity)
            {
                if (!Keys.Contains(key))
                {
                    Keys.Add(key);
                    Values.Add(value);
                    Count++;
                    Sort();
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            Count = 0;
            Keys.Clear();
            Values.Clear();
        }

        public MySortedDictionary<K, T> Clone()
        {
            return new MySortedDictionary<K, T>() { Capacity = this.Capacity, Count = this.Count, Keys = this.Keys, Values = this.Values };
        }

        public void Remove(T value)
        {
            int index = Values.IndexOf(value);
            if (index >= 0)
            {
                Keys.RemoveAt(index);
                Values.RemoveAt(index);
                Count--;
            }
        }

        public void RemoveAt(int index)
        {
            if (Count > 0)
            {
                if (index >= 0 && index < Count)
                {
                    Keys.RemoveAt(index);
                    Values.RemoveAt(index);
                    Count--;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Список пуст");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            indexNow++;
            return (indexNow < Count);
        }

        public object Current
        {
            get
            {
                return (Key: Keys[indexNow], Value: Values[indexNow]);
            }
        }


        public void Reset()
        {
            indexNow = -1;
        }
    }
}
