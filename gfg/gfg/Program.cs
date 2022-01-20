using System;

namespace gfg
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(5);
            head.next = new Node(7);
            head.next.next = new Node(2);
            head.next.next.next = new Node(9);
            head.next.next.next.next = new Node(1);
            var d = S.mergeSort(head);
        }
        public static Tree ConvetPreOrderToBST(int[] pre, int n)
        {
            Tree node = getTree(pre, 0 , n-1);
            return node;
        }

        private static Tree getTree(int[] pre, int s, int e)
        {
            if (s <= e)
            {
                Tree node = new Tree(pre[s]);
                int index = getBSTIndex(pre, pre[s], s, e);
                if(index != -1)
                {
                    node.left = getTree(pre, s + 1, index);
                    node.right = getTree(pre, index + 1, e);
                }

                return node;
            }
            else
            {
                return null;
            }
        }

        private static int getBSTIndex(int[] pre, int data, int start, int end)
        {
            int s = start;
            int e = end;
            while (s <= e)
            {
                //{40,30,35,80,100}
                int mid = s + (e - s) / 2;
                if((mid + 1 <= end && pre[mid + 1] > data && pre[mid] < data) ||(mid == end))
                {
                    return mid;
                }
                if(pre[mid] > data)
                {
                    e = mid - 1;
                }
                else
                {
                    s = mid + 1;
                }

            }
            return -1;
        }
    }
    class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
        }
    }
    class S
    {
        //Complete this function
        public static Node mergeSort(Node head)
        {
            //single node or null
            if (head == null || head.next == null)
            {
                return head;
            }
            Node mid = getMid(head);
            Node midNext = mid.next;
            mid.next = null;
            mergeSort(head);
            mergeSort(midNext);
            return Merge(head, midNext);
        }
        public static Node Merge(Node n1, Node n2)
        {
            Node result = null;
            Node temp = null;
            while (n1 != null && n2 != null)
            {
                if (n1.data < n2.data)
                {
                    if (result == null)
                    {
                        temp = new Node(n1.data);
                        result = temp;
                    }
                    else
                    {
                        temp.next = new Node(n1.data);
                        temp = temp.next;
                    }
                    n1 = n1.next;
                }
                else
                {
                    if (result == null)
                    {
                        temp = new Node(n2.data);
                        result = temp;
                    }
                    else
                    {
                        temp.next = new Node(n2.data);
                        temp = temp.next;
                    }
                    n2 = n2.next;
                }
            }
            while (n1 != null)
            {
                temp.next = new Node(n1.data);
                temp = temp.next;
                n1 = n1.next;

            }
            while (n2 != null)
            {
                temp.next = new Node(n2.data);
                temp = temp.next;
                n2 = n2.next;
            }
            return result;

        }
        public static Node getMid(Node head)
        {
            Node slow = head;
            Node fast = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

    }
}
