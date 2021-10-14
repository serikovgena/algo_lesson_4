using lesson4.BinaryTree;

namespace lesson4
{
  class BTree : ITree {
    BTreeNode root;
    public BTree() { 
    }

    public void AddItem(int value) {
      root = GetFreeNode(root, value);
    }

    private BTreeNode GetFreeNode(BTreeNode node, int value) {
      if (node == null)
        return new BTreeNode { Value = value };

      if (node.Value < value) {
          node.LeftChild = GetFreeNode(node.LeftChild, value);
      }
      else if(node.Value > value) {
        node.RightChild = GetFreeNode(node.RightChild, value);
      }
      else {
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
      else {
        if (node.Value < value) {
          return GetNode(node.LeftChild, value);
        }
        else if (node.Value > value) {
          return GetNode(node.RightChild, value);
        }
        else
          return node;
      }
    }

    public BTreeNode GetRoot() => root;

    public void PrintTree() {
      throw new System.NotImplementedException();
    }

    public void RemoveItem(int value) {
      throw new System.NotImplementedException();
    }
  }
}
