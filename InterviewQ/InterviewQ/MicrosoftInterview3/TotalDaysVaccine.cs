using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQ.MicrosoftInterview3
{
    public class TotalDaysVaccine
    {
        public static int GetTotalDaysVaccine(int[,] states)
        {
            int count = 0;
            int m = states.GetLength(0);
            int n = states.GetLength(1);
            Queue<Entry> q = new Queue<Entry>();
            Entry started = new Entry(0, 0, 0);
            for(int i=0; i < m; i++)
            {
                for(int j=0; j<n; j++)
                {
                    if(states[i,j] == 1)
                    {
                        started = new Entry(i, j, 0);
                    }
                }
            }
            q.Enqueue(started);

            while (q.Count > 0)
            {
                Entry curr = q.Dequeue();
                int i = curr.i;
                int j = curr.j;
                int d = curr.distance;
                if(i-1>=0 && states[i-1, j] == 0)
                {
                    states[i - 1, j] = d + 1;
                    q.Enqueue(new Entry(i - 1, j, d + 1));
                }
                if (i + 1 < m && states[i + 1, j] == 0)
                {
                    states[i + 1, j] = d + 1;
                    q.Enqueue(new Entry(i + 1, j, d + 1));
                }
                if (j - 1 >= 0 && states[i, j - 1] == 0)
                {
                    states[i, j - 1 ] = d + 1;
                    q.Enqueue(new Entry(i, j - 1, d + 1));
                }
                if (j + 1 < n && states[i, j + 1] == 0)
                {
                    states[i, j + 1] = d + 1;
                    q.Enqueue(new Entry(i, j + 1, d + 1));
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (states[i, j] == 0)
                    {
                        return -1;
                    }
                    if (states[i, j] > count)
                        count = states[i, j];
                }
            }
            return count;
        }
    }
    public class Entry
    {
        public int i;
        public int j;
        public int distance;
        public Entry(int i, int j, int dis)
        {
            this.i = i;
            this.j = j;
            this.distance = dis;
        }
    }
}
