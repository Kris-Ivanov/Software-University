﻿using System;
using System.Text;

namespace _03.GenericList
{
    [Version(1, 0)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int count = 0;

        public GenericList(int capacity = DefaultCapacity)
        {
            elements = new T[capacity];
        }

        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return elements[index];
            }
        }

        public void Add(T element)
        {
            if (this.count >= this.Capacity)
            {
                this.Expand();
            }

            this.elements[count] = element;
            this.count++;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.count; i++)
			{
			    if (this.elements[i].Equals(element))
                {
                    return i;
                }
			}
            return -1;
        }

        public bool Contains(T element)
        {
            if (this.IndexOf(element) != -1)
            {
                return true;
            }
            return false;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.count >= this.Capacity)
            {
                this.Expand();
            }

            for (int i = this.count; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.count++;
            this.elements[index] = element;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index; i < this.count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.count--;
            this.elements[count] = default(T);
        }

        public void Clear()
        {
            this.elements = new T[this.Capacity];
            this.count = 0;
        }

        public T Max()
        {
            if (this.count < 1)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            T max = this.elements[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }

        public T Min()
        {
            if (this.count < 1)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            T min = this.elements[0];
            for (int i = 1; i < this.count; i++)
            {
                if (this.elements[i].CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }

        private void Expand()
        {
            T[] expanded = new T[this.Capacity * 2];
            Array.Copy(this.elements, expanded, this.Capacity);
            this.elements = expanded;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(this.count);
            for (int i = 0; i < this.count - 1; i++)
            {
                result.Append(this.elements[i] + ", ");
            }
            result.Append(this.elements[count - 1]);
            return result.ToString();
        }
    }
}