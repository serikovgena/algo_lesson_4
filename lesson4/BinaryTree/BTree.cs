using lesson4.BinaryTree;
using System;

namespace lesson4
{
    class BTree : ITree
    {
        BTreeNode root;
        int size = 0;
        public BTree() {
        }

        public void AddItem(int value) {
            root = GetFreeNode(root, value);
        }

        private BTreeNode GetFreeNode(BTreeNode node, int value) {
            if (node == null)
            {
                size++;
                return new BTreeNode { Value = value };
            }

            if (node.Value < value)
            {
                node.LeftChild = GetFreeNode(node.LeftChild, value);
            }
            else if (node.Value > value)
            {
                node.RightChild = GetFreeNode(node.RightChild, value);
            }
            else
            {
                node.Value = value;
            }

            return node;
        }

        public BTreeNode GetNodeByValue(int value) {
            return GetNode(root, value);
        }

        private BTreeNode GetNode(BTreeNode node, int value) {
            if (node == null)
                return null;
            else
            {
                if (node.Value < value)
                {
                    return GetNode(node.LeftChild, value);
                }
                else if (node.Value > value)
                {
                    return GetNode(node.RightChild, value);
                }
                else
                    return node;
            }
        }

        public BTreeNode GetRoot() {
            if (root == null)
                throw new System.Exception("BinaryTree container is empty");
            else
                return root;
        }


        public void PrintTree() {
            PrintNode(root, 0);
        }

        private void PrintNode(BTreeNode tree, int edge = 0) {
            if (tree == null) return;

             var edges = edge == 0 ? (int)Math.Log2(size) : edge;
             var tab = edge * 10;
             Console.Write($"({tree.Value})");       
         
            if (tree.LeftChild != null)
                PrintNode(tree.LeftChild);

            if (tree.RightChild != null)
                PrintNode(tree.RightChild);

        }

        public void RemoveItem(int value) {
            var subTree = GetNodeByValue(value);
            if (subTree == null) return;

            // remove root
            BTreeNode tree;
            if (subTree == root)
            {
                if (subTree.RightChild != null)
                {
                    tree = subTree.RightChild;
                }
                else tree = subTree.LeftChild;

                while (tree.LeftChild != null)
                {
                    tree = tree.LeftChild;
                }

                var temp = tree.Value;
                RemoveItem(temp);
                subTree.Value = temp;
                size--;
                return;
            }

            // remove leafs
            if (subTree.LeftChild == null
             && subTree.RightChild == null
             && subTree.Parent != null)
            {
                if (subTree == subTree.Parent.LeftChild)
                    subTree.Parent.LeftChild = null;
                else
                {
                    subTree.Parent.RightChild = null;
                }
                size--;
                return;
            }

            // remove node with left subtree without right subtree
            if (subTree.LeftChild != null && subTree.RightChild == null)
            {
                // substitude parent
                subTree.LeftChild.Parent = subTree.Parent;
                if (subTree == subTree.Parent.LeftChild)
                {
                    subTree.Parent.LeftChild = subTree.LeftChild;
                }
                else if (subTree == subTree.Parent.RightChild)
                {
                    subTree.Parent.RightChild = subTree.LeftChild;
                }
                size--;
                return;
            }

            // remove node with right subtree without left subtree
            if (subTree.LeftChild == null && subTree.RightChild != null)
            {
                // substitude parent
                subTree.RightChild.Parent = subTree.Parent;
                if (subTree == subTree.Parent.LeftChild)
                {
                    subTree.Parent.LeftChild = subTree.RightChild;
                }
                else if (subTree == subTree.Parent.RightChild)
                {
                    subTree.Parent.RightChild = subTree.RightChild;
                }
                size--;
                return;
            }

            // remove node that has both subTree
            if (subTree.RightChild != null && subTree.LeftChild != null)
            {
                tree = subTree.RightChild;
                while (tree.LeftChild != null)
                {
                    tree = tree.LeftChild;
                }

                if (tree.Parent == subTree)
                {
                    tree.LeftChild = subTree.LeftChild;
                    subTree.LeftChild.Parent = tree;
                    tree.Parent = subTree.Parent;
                    if (subTree == subTree.Parent.LeftChild)
                    {
                        subTree.Parent.LeftChild = tree;
                    }
                    else if (subTree == subTree.Parent.RightChild)
                    {
                        subTree.Parent.RightChild = tree;
                    }
                    size--;
                    return;
                }
                else {
                    if (tree.RightChild != null)
                    {
                        tree.RightChild.Parent = tree.Parent;
                    }
                    tree.Parent.LeftChild = tree.RightChild;
                    tree.RightChild = subTree.RightChild;
                    tree.LeftChild = subTree.LeftChild;
                    subTree.LeftChild.Parent = tree;
                    subTree.RightChild.Parent = tree;
                    tree.Parent = subTree.Parent;
                    if (subTree == subTree.Parent.LeftChild)
                    {
                        subTree.Parent.LeftChild = tree;
                    }
                    else if (subTree == subTree.Parent.RightChild)
                    {
                        subTree.Parent.RightChild = tree;
                    }
                    size--;
                    return;
                }
            }
            return;
        }


    }
}
