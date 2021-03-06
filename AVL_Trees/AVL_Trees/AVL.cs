﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Trees
{
    class AVL<T> where T : IComparable
    {
        AVLNode<T> Root;

        public int Count { get; private set; }

        public void Insert(T value)
        {
            Count++;
            if (Root == null)
            {
                Root = new AVLNode<T>(value);
            }
            else
            {
                AVLNode<T> tempNode = Root;

                while (tempNode != null)
                {
                    if (value.CompareTo(tempNode.Data) < 0)
                    {
                        if (tempNode.LeftChild != null)
                        {
                            tempNode = tempNode.LeftChild;
                        }
                        else
                        {
                            //add a left child
                            tempNode.LeftChild = new AVLNode<T>(value, tempNode);
                            break;
                        }
                    }
                    else if (value.CompareTo(tempNode.Data) >= 0)
                    {
                        if (tempNode.RightChild != null)
                        {
                            tempNode = tempNode.RightChild;
                        }
                        else
                        {
                            tempNode.RightChild = new AVLNode<T>(value, tempNode);
                            break;
                        }
                    }
                }

                Balance(tempNode);
            }


        }

        public bool Delete(T value)
        {
            AVLNode<T> tempnode = Root;
            while (tempnode != null)
            {
                if (value.CompareTo(tempnode.Data) < 0)
                {
                    tempnode = tempnode.LeftChild;
                }
                else if (value.CompareTo(tempnode.Data) > 0)
                {
                    tempnode = tempnode.RightChild;
                }
                else
                {
                    RemoveNode(tempnode);
                    Balance(tempnode.Parent);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        private void RemoveNode(AVLNode<T> node)
        {
            if (node.ChildCount == 0)
            {
                //remove parent pointer to us
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = null;
                }
                else
                {
                    node.Parent.RightChild = null;
                }
            }
            else if (node.ChildCount == 1)
            {
                //link parent and child 
                var child = node.FirstChild;
                child.Parent = node.Parent;
                if (node.Parent.LeftChild == node)
                {
                    node.Parent.LeftChild = child;
                }
                else
                {
                    node.Parent.RightChild = child;
                }
            }
            else if (node.ChildCount == 2)
            {
                //find prime node: left once, all the way right
                //copy prime nodes value into temp value
                //recursive delete prime node (non-recursive: make another function)
                var primeNode = node.LeftChild;
                while (primeNode.RightChild != null)
                {
                    primeNode = primeNode.RightChild;
                }
                node.Data = primeNode.Data;
                RemoveNode(primeNode);
            }
        }

        private void Balance(AVLNode<T> node)
        {
            if(node == null)
            {
            //update height of node
            node.UpdateHeight();
            //get balance of node
            if (node.Balance > 1)
            {
                RotateLeft(node);
                if(node.Balance > 2)
                {
                    RotateRight(node);
                }
            }
            if(node.Balance < -1)
            {
                RotateRight(node);
                if (node.Balance < -2)
                {
                    RotateLeft(node);
                }
            }
            //if balance > 1
            //rotate left

            //if balance < 1
            //rotate right

            if (node.Parent != null)
            {
                Balance(node.Parent);
            }
            }
            
        }

        private void RotateLeft(AVLNode<T> node)
        {
            var parent = node.Parent; //could be null
            var child = node.RightChild; //cant be null
            var last = child.LeftChild; //could be null

            child.LeftChild = node;
            child.Parent = parent;

            node.Parent = child;
            node.RightChild = last;

            if (last != null)
            {
                last.Parent = node;
            }

            if (parent != null)
            {
                if (parent.LeftChild == node)
                {
                    parent.LeftChild = child;
                }
                else if (parent.RightChild == node)
                {
                    parent.RightChild = child;
                }
            }

            node.UpdateHeight();
            child.UpdateHeight();
        }

        private void RotateRight(AVLNode<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            var last = child.LeftChild;

            child.RightChild = node;
            child.Parent = last;

            node.Parent = child;
            node.LeftChild = last;

            if (last != null)
            {
                last.Parent = node;
            }

            if (parent != null)
            {
                if (parent.RightChild == node)
                {
                    parent.RightChild = child;
                }
                else if (parent.RightChild == node)
                {
                    parent.LeftChild = child;
                }
            }

            node.UpdateHeight();
            child.UpdateHeight();
        }
    }
}

