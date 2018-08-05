using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL<int> avl = new AVL<int>();
            avl.Insert(1);
            avl.Insert(2);
            avl.Insert(3);
            avl.Insert(4);
            avl.Insert(5);
            avl.Insert(6);
            avl.Insert(7);
            avl.Insert(8);
            avl.Insert(9);
            avl.Insert(10);
            avl.Delete(2);
            avl.Delete(3);
            avl.Delete(4);
            avl.Delete(5);
            avl.Delete(6);
            avl.Delete(7);
            avl.Delete(8);
            avl.Delete(9);
            avl.Delete(10);
            avl.Insert(2);
            avl.Insert(3);
            avl.Insert(4);
            avl.Insert(5);
            avl.Insert(6);
            avl.Insert(7);
            avl.Insert(8);
            avl.Insert(9);


            Console.ReadKey();
        }

    }
}




