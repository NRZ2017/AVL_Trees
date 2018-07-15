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
            avl.Insert(22);
            avl.Insert(30);
            avl.Insert(10);
            avl.Insert(3);
            avl.Delete(10);
            avl.Delete(22);
        }

    }
}




