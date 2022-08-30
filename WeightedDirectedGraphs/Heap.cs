using System;
using System.Collections.Generic;
using System.Text;

namespace Heap_Tree
{
    public class Heap<T> where T : IComparable<T>
    {
        private T[] items;
        public int Count { get; private set; }
        public int Capacity { get { return items.Length; } }

        public Heap(int capacity)
        {
            items = new T[capacity];
        }

        public void Push(T item)
        {
            
            //resize if the array is full
            if (Count >= items.Length)
            {
                T[] newItems = new T[items.Length * 2];

                for (int i = 0; i < Count; i++)
                {
                    newItems[i] = items[i];
                }
                items = newItems;
            }

            items[Count] = item;

            HeapifyUp(Count);

            Count++; 
        }

        public void HeapifyUp(int index)
        {
            if (index == 0) return;

            int parent = (index - 1) / 2;

            if (items[index].CompareTo(items[parent]) > 0)
            {
                T temp = items[parent];
                items[parent] = items[index];
                items[index] = temp;
            }
            HeapifyUp(parent);
        }
        public void HeapifyDown(int index)
        {
            int leftChild = index * 2 + 1;

            int rightChild = index * 2 + 2;

            //index has no children
            if (rightChild >= Count && leftChild >= Count) return;
            //index has a left child and no right child
            else if (rightChild >= Count)
            {
                if (items[index].CompareTo(items[leftChild]) < 0)
                {
                    T temp = items[index];
                    items[index] = items[leftChild];
                    items[leftChild] = temp;
                    HeapifyDown(leftChild);
                }
                else
                {
                    return;
                }
            }

            if (items[index].CompareTo(items[leftChild]) < 0 && items[index].CompareTo(items[rightChild]) < 0)
            {
                if (items[leftChild].CompareTo(items[rightChild]) < 0)
                {
                    T temp = items[index];
                    items[index] = items[rightChild];
                    items[rightChild] = temp;
                    HeapifyDown(rightChild);
                }
                else
                {
                    T temp = items[index];
                    items[index] = items[leftChild];
                    items[leftChild] = temp;
                    HeapifyDown(leftChild);
                }
            }
            else if (items[index].CompareTo(items[leftChild]) < 0)
            {
                T temp = items[index];
                items[index] = items[leftChild];
                items[leftChild] = temp;
                HeapifyDown(leftChild);
            }
            else if (items[index].CompareTo(items[rightChild]) < 0)
            {
                T temp = items[index];
                items[index] = items[rightChild];
                items[rightChild] = temp;
                HeapifyDown(rightChild);
            }

        }

        public T Pop()
        {
            if (Count == 0) throw new Exception("empty");

            T root = items[0];
                
            items[0] = items[Count - 1];         

            Count--;

            HeapifyDown(0);

            return root;
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
