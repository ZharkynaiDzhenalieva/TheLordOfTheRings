using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLHJZJ_HomeProject
{
    internal class SauronsInfluence<T>
    {

        class ListItem
        {
            public T content;
            public ListItem next;

        }

        private ListItem head;


        //-------------




        public void Insert2Front(T newContent)
        {
            ListItem newItem = new ListItem();
            newItem.content = newContent;
            newItem.next = head; // the newItem is pointing where the head is pointing (the former first element)
            head = newItem; //head should point to the newItem, as it now is the first element
        }

        public void Insert2Back(T newContent)
        {
            ListItem newElement = new ListItem();
            newElement.content = newContent;
            if (head == null)   // the list is empty
            {
                head = newElement;
            }
            else    // list has some elements in it
            {
                ListItem p = head; //"ListItem p" serves as a placeholder
                while (p.next != null)
                {
                    p = p.next;
                }
                p.next = newElement;
            }
        }





        public void Remove(T data)
        {
            ListItem p = head;  //set an element to the head
            ListItem e = null;  //set an element we will use as storage (set it to null for the moment)

            while (p != null && !p.content.Equals(data))
            {
                e = p;
                p = p.next;
            }
            if (p != null)
            {
                if (e == null)
                {
                    head = p.next;
                }
                else
                {
                    e.next = p.next;  //we skip over "p" and set "e.next" to point to the element after it, which is p.next                
                    // FREE(p) 
                }
            }
            else
            {
                throw new Exception("Data is not in the list.");
            }
        }



        public T Search(T a)
        {
            ListItem p = head;
            while (p != null && !p.content.Equals((a)))
            {
                p = p.next;
            }
            if (p != null)
            {
                return p.content;
            }
            else
            {
                throw new Exception("Item not found");
            }
        }

        public void Traversal() //goes through the list and puts each item through some process (see below)
        {
            ListItem p = head;
            while (p != null)
            {
                Process(p);
                p = p.next;
            }


        }

        private void Process(ListItem p)
        {
            Console.WriteLine(p.content);
        }








        public int Count() //counts how many items there are on the list
        {
            int count = 0;
            ListItem p = head;
            while (p != null)
            {
                count++;
                p = p.next;
            }
            return count;


        }


        public T[] CopyToArray() //copies the linked list to an array
        {
            T[] array = new T[Count()];
            int i = 0;

            ListItem p = head;
            while (p != null)
            {
                array[i] = p.content;
                i++;
                p = p.next;
            }

            return array;
        }












    }
}