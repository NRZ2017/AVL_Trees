using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Trees
{
    class AVLNode<T>
    {
        public T Data;
        public AVLNode<T> LeftChild;
        public AVLNode<T> RightChild;
        public AVLNode<T> Parent;
        public int Height { get; set; }


        public int ChildCount
        {
            get
            {
                int childCount = 0;
                if (LeftChild != null) childCount++;
                if (RightChild != null) childCount++;
                return childCount;
            }
        }

        public AVLNode<T> FirstChild
        {
            get
            {
                if (LeftChild != null)
                {
                    return LeftChild;
                }
                else if (RightChild != null)
                {
                    return RightChild;
                }
                else
                {
                    return null;
                }

            }
        }

        public int Balance
        {
            get
            {
                int right = (RightChild != null) ? RightChild.Height : 0;
                int left = (LeftChild != null) ? LeftChild.Height : 0;
                return right - left;
            }
        }


        public AVLNode(T data, AVLNode<T> parent = null)
        {
            Data = data;
            Parent = parent;
            Height = 1;

        }

        public void UpdateHeight()
        {
            int right = (RightChild != null) ? RightChild.Height : 0;
            int left = (LeftChild != null) ? LeftChild.Height : 0;

            Height = Math.Max(left, right) + 1;
        }
        //UpdateHeight
        //find which child has the larger height
        //Height = TallerChild.Height + 1
    }
}
