using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RealWorld
{
    class Character_List
    {
        class Node
        {
            //Attributes
            public Character data;
            public Node next;

            //Builders
            public Node()
            {
                next = null;
                data = new Character();
            }

            public Node(Character pdata)
            {
                next = null;
                data = pdata;
            }
        }


        //*********************************************************
        //*********************************************************

        private Node first;

        //---------------------------------------------
        public Character_List()
        {
            Empty_List();
        }

        //---------------------------------------------
        public void Empty_List()
        {
            first = null;
        }

        //---------------------------------------------
        public Boolean Is_Empty()
        {
            return first == null;
        }

        //---------------------------------------------

        public void Add_First(Character s)
        {
            Node newCharacter = new Node(s);

            if (first == null)
                first = newCharacter;
            else
            {
                newCharacter.next = first;
                first = newCharacter;                
            }
        }


        //---------------------------------------------
        public void Add_Last(Character s)
        {
            Node aux = new Node(s);
            Node rec_aux;

            if (first == null)
            {
                aux.next = first;
                first = aux;
            }
            else
            {
                rec_aux = first;
                while (rec_aux.next != null)
                    rec_aux = rec_aux.next;
                rec_aux.next = aux;
            }
        }


        //---------------------------------------------
        public void Remove_First()
        {
            Node aux;

            if (!Is_Empty())
            {
                aux = first;
                first = first.next;
                aux = null;  // mark as rubbish
            }
        }

        //---------------------------------------------
        public void Remove_Last()
        {

            Node aux = first;
            if (aux.next == null)
                Empty_List();

            if (!Is_Empty())
            {
                aux = first;
                while (aux.next.next != null)
                    aux = aux.next;
                aux.next = null;
            }

        }

        //---------------------------------------------
        public Character Get_Last()
        {
            Character element = null;
            Node aux = null;

            if (!Is_Empty())
            {
                aux = first;
                while (aux.next != null)
                    aux = aux.next;
                element = aux.data;
            }
            return element;
        }

        //---------------------------------------------
        public Character Get_First()
        {
            Character element = null;

            if (!Is_Empty())
                element = first.data;
            return element;
        }


        //---------------------------------------------
        public int elements()
        {
            Node aux = null;
            int i = 0;
            aux = first;

            while (aux != null)
            {
                aux = aux.next;
                i += 1;
            }
            return i;
        }

        public void sortC_list()
        {
            if (first == null || first.next == null) return;

            Node a = first,
                    b = first.next,
                    preA = null;

            bool sorted = false;

            //sorting the list
            while (!sorted || b != null)
            {
                if (a.data.getChances() > b.data.getChances())
                {
                    a.next = b.next;
                    b.next = a;
                    if (preA != null) preA.next = b;
                    else first = b;
                    preA = b;
                    b = a.next;
                    sorted = false;
                }
                else
                {
                    preA = a;
                    b = b.next;
                    a = a.next;
                }

                if (b == null && !sorted)
                {
                    sorted = true;
                    a = first;
                    b = first.next;
                    preA = null;
                }
            }
        }


        public void deleteNulls()
        {
            Node    a = first, 
                    aux = null;

            while(a != null)
            {
                //linking filled nodes
                if (a == first && a.data == null)
                {
                    aux = a;
                    first = a.next;
                    a = first;
                }
                else if (a.next != null && a.next.data == null)
                {
                    aux = a.next;
                    a.next = a.next.next;
                }
                else a = a.next;

                //unlinking empty node.next
                if (aux != null)
                {
                    aux.next = null;
                    aux = null;
                }       
            }
        }

        
                public void print()
                {
                    Node aux;
                    Character Character;
                    aux = first;
                    while (aux != null)
                    {
                        Character = aux.data;
                        Character.print();
                        aux = aux.next;
                    }

                    Console.WriteLine("Elements " + elements());
                }
                
    }
}
