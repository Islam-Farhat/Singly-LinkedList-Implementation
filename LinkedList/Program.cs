#region Singly LinkedList


using System;

namespace Program
{
    class Node
    {
        public object data;
        public Node next;
        public Node(object data)
        {
            this.data = data;
            // this.next = null;    //  defult value for next = null 
        }
        public Node()
        {

        }
    }
    public class LinkedList
    {
        Node head;
        public LinkedList() //Constructor
        {

        }
        void insertAtEnd(object value)
        {
            if (head == null)
            {
                head = new Node(value);
                return;
            }
            Node temp = head;         // temp and head indicates same address
            while (temp.next != null)
            {
                temp = temp.next;     //get the address of the next node
            }
            Node newNode = new Node(value);
            temp.next = newNode;
            // temp.next = new Node(value);
        }

        void insertAtFirst(int value)
        {
            Node newNode = new Node(value);
            newNode.next = head;
            head = newNode;
        }

        void insertAfter(object after, object value)
        {
            Node previous = Find(after); //node1
            if (previous == null)
            {
                insertAtEnd(value);
            }
            else
            {
                Node newNode = new Node(value);
                newNode.next = previous.next.next;
                previous.next = newNode;

                //solution 2
                //Node node2 = previous.next;
                //previous.next = newNode;
                //newNode.next = node2;

            }
        }

        void printLinkedList()
        {
            Node temp = head;
            while (temp != null)
            {

                Console.WriteLine(temp.data);
                temp = temp.next;
            }
            Console.WriteLine("\n");
        }

        void RemoveLast()
        {
            if (head == null)
            {
                return;
            }
            Node temp = head;
            while (temp.next.next != null)
            {
                temp = temp.next;
            }
            temp.next = null;
        }

        void RemoveFirst()
        {
            if (head == null)
            {
                return;
            }
            head = head.next;
        }

        void Remove(object value)
        {
            Node previouse = FindPrevious(value);
            if (previouse == null)
            {
                return;
            }
            else
            {
                Node target = previouse.next;
                previouse.next = target.next;
                target.next = null;

                //previouse.next = previouse.next.next;
                //previouse.next.next = null;
            }
        }

        Node Find(object value)
        {
            Node temp = head;
            while (temp.next != null)
            {
                if (temp.data.Equals(value))
                {
                    // Console.WriteLine($"Element: {temp.data} is found");
                    return temp;
                }
                temp = temp.next;
            }
            Console.WriteLine($"Element: {value} isn't found");
            return null;
        }

        Node FindPrevious(object value)
        {
            Node temp = head;
            while (temp.next != null)
            {
                if (temp.next.data.Equals(value))
                {

                    return temp;
                }
                temp = temp.next;
            }

            return null;
        }

        bool Contains(object value)
        {
            if (Find(value) != null)
            {
                return true;
            }
            return false;
        }

        int Count()
        {
            int count = 0;
            Node temp = head;
            if (head == null)
            {
                return 0;
            }
            else
            {
                while (temp != null)
                {
                    count++;
                    temp = temp.next;
                }
                return count;
            }
        }

        public static void Main()
        {
            LinkedList list = new LinkedList();
            //Console.WriteLine(list.Count());
            list.insertAtEnd(100);
            list.insertAtEnd(200);
            list.insertAtEnd(300);
            list.insertAtEnd(400);

            Console.WriteLine(list.Count());
            list.printLinkedList();

            list.insertAtEnd(500);
            list.insertAtEnd(600);
            list.printLinkedList();

            list.insertAtFirst(50);
            list.insertAtFirst(40);
            list.insertAtEnd(700);
            list.printLinkedList();

            if (list.Find(1020) != null)
            {
                Console.WriteLine($"Element: {list.Find(100).data} is found");
            }
            Console.WriteLine(list.Contains(100));

            list.insertAfter(400, 450);
            list.insertAfter(3300, 450);  //insert at end

            list.printLinkedList();

            Console.WriteLine($"Element: {list.FindPrevious(100).data} is found\n"); //return 50

            list.RemoveLast(); //remove last node 450
            list.printLinkedList();

            list.RemoveFirst(); //remove first node 40
            list.printLinkedList();

            list.Remove(200);
            list.printLinkedList();
        }
    }
}


#endregion
