﻿using System;
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

            public void PreorderRecurse(Node root)
            {
                if (root != null)
                {
                    // N - L - R pattern
                    root.DisplayNode();
                    PreorderRecurse(root.Left);
                    PreorderRecurse(root.Right);
                }
            }

            public void PreorderIterative(Node root)
            {
                if (root == null)
                {
                    return;
                }

                Stack<Node> stack = new Stack<Node>();
                stack.Push(root);

                while (stack.Count >= 1)
                {
                    //immediately record first node in stack which starts with root
                    Node topNode = stack.Pop();
                    topNode.DisplayNode();

                    if (topNode.Right != null) // check for right children, if exist add to stack
                    {
                        stack.Push(topNode.Right);
                    }
                    if (topNode.Left != null) // then check for left children, if exist add to stack which ensures N-L-R pattern since L node being placed on top of R node in stack
                    {
                        stack.Push(topNode.Left);
                    }
                }
            }

            public void InorderRecurse(Node root)
            {
                if (root != null)
                {
                    // L - N - R pattern
                    InorderRecurse(root.Left);
                    root.DisplayNode();
                    InorderRecurse(root.Right);
                }
            }

            public void InorderIterative(Node root)
            {
                Node curr = root;
                Stack<Node> stack = new Stack<Node>();

                while (curr != null || stack.Count != 0) // need both checks bc this solution relies on setting pointer to null to deplete stack
                {
                    while (curr != null)
                    {
                        //traversing entire left side of tree by starting w/ root at bottom of stack
                        stack.Push(curr); // starting with root placing at bottom of stack
                        curr = curr.Left; // adding left children to stack until null, will check for left children
                    }

                    curr = stack.Pop(); //if children nodes are null will remove parent node and record
                    curr.DisplayNode();
                    curr = curr.Right; //check right children which are added to stack. after recording right node parent's parent at top of stack
                }
            }

            public void PostorderRecurse(Node root)
            {
                if (root != null)
                {
                    // L - R - N pattern
                    PostorderRecurse(root.Left);
                    PostorderRecurse(root.Right);
                    root.DisplayNode();
                }
            }

            public void PostorderIterative(Node root)
            {
                if (root == null)
                    return;
                Stack<Node> stack = new Stack<Node>();
                stack.Push(root);

                Node prev = null;

                while (stack.Count != 0)
                {
                    Node current = stack.Peek(); // recording what's at bottom of stack, root should come off last in postorder
                    if (prev == null || prev.Left == current || prev.Right == current) // prev init as null so enter this test which checks if you're on a child of the previous node
                    {
                        if (current.Left != null)
                        {
                            stack.Push(current.Left); // place left nodes on top of stack traversing down left side
                        }
                        else if (current.Right != null)
                        {
                            stack.Push(current.Right); // place right node on top of stack to traverse right side after left
                        }
                        else
                        {
                            stack.Pop();
                            current.DisplayNode();
                        }
                    }
                    else if (current.Left == prev) // move up tree and check for children on right of current, enter above test if so and traverse right accordingly
                    {
                        if (current.Right != null)
                        {
                            stack.Push(current.Right);
                        }
                        else
                        {
                            stack.Pop();
                            current.DisplayNode();
                        }
                    }
                    else if (current.Right == prev) //if current is right child of parent node then left and right have been recorded and can finally record N
                    {
                        stack.Pop();
                        current.DisplayNode();
                    }
                    prev = current; // prior to moving onto next node record previous to use with tests
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
            Node root = tree.TreeRoot();
            Console.WriteLine("Preorder Recursive Traversal: ");
            tree.PreorderRecurse(root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Iterative Traversal: ");
            tree.PreorderIterative(root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Inorder Recurisve Traversal: ");
            tree.InorderRecurse(root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Inorder Iterative Traversal: ");
            tree.InorderIterative(root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Recursive Traversal: ");
            tree.PostorderRecurse(root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Iterative Traversal: ");
            tree.PostorderIterative(root);
            Console.ReadLine();
        }
    }
}
