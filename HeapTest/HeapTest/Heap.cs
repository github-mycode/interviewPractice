using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HeapTest
{
    public class Heap
    {
        private int[] data;
        public int capacity { get; set; }
        public int count = 0;
        public Heap(int c)
        {
            capacity = c;
            data = new int[c];
        }
        public int GetParentIndex(int i)
        {
            return i / 2;
        }
        public int GetLeftIndex(int i)
        {
            return (2*i) + 1;
        }
        public int GetRightIndex(int i)
        {
            return (2*i) + 2;
        }
        public void Add(int val)
        {
            if(count < capacity)
            {
                int index = count;
                data[index] = val;
                count++;
                HeapifyUp(index);

            }
            else
            {
                //Storage full
            }
        }
        public int Remove(int index)
        {
            int res = data[index];
            data[index] = data[--count];
            data[count] = res;
            HeapifyDown(index);
            return res;
        }
        public void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public void HeapifyUp(int index)
        {
            if(index >= 0)
            {
                int pIndex = GetParentIndex(index);
                if (data[pIndex] < data[index])
                {
                    Swap(data, pIndex, index);
                    HeapifyUp(pIndex);
                }
            }
        }
        public void HeapifyDown(int index)
        {
            if (index < count)
            {
                int left = GetLeftIndex(index);
                int right = GetRightIndex(index);
                int tempData = data[index];
                if (left != -1 && left < count)
                {
                    tempData = Math.Max(tempData, data[left]);
                    if(right != -1 && right < count)
                    {
                        tempData = Math.Max(tempData, data[right]);
                    }
                }
                if(tempData != data[index])
                {
                    int temp = tempData == data[left] ? left : right;
                    Swap(data, temp, index);
                    HeapifyDown(temp);
                }
            }
        }
    }
}