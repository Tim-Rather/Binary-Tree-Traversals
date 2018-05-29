using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversals
{

    class Program
    {
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public void DisplayNode()
            {
                Console.Write(Data + " ");
            }
        }

        public class BinaryTree
        {

            public Node root;
            public BinaryTree()
            {
                root = null;
            }
            public Node TreeRoot()
            {
                return root;
            }
            public void Insert(int data)
            {
                Node newNode = new Node();
                newNode.Data = data;
                if (root == null)
                    root = newNode;
                else
                {
                    Node current = root;
                    Node parent;
                    while (true)
                    {
                        parent = current;
                        if (data < current.Data)
                        {
                            current = current.Left;
                            if (current == null)
                            {
                                parent.Left = newNode;
                                return;
                            }
                        }
                        else
                        {
                            current = current.Right;
                            if (current == null)
                            {
                                parent.Right = newNode;
                                return;
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.Insert(60);
            tree.Insert(27);
            tree.Insert(25);
            tree.Insert(14);
            tree.Insert(89);
            tree.Insert(34);
            tree.Insert(9);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(76);
            tree.Insert(72);
            tree.Insert(100);

        }
    }
}
