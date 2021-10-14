using System.Collections.Generic;

namespace lesson4.BinaryTree {
  public static class BTreeHelper {
    public static BTreeNodeInfo[] GetTreeInLine(ITree tree) {
      var bufer = new Queue<BTreeNodeInfo>();
      var returnArray = new List<BTreeNodeInfo>();
      var root = new BTreeNodeInfo() { Node = tree.GetRoot() };
      bufer.Enqueue(root);

      while (bufer.Count != 0) {
        var element = bufer.Dequeue();
        returnArray.Add(element);

        var depth = element.Depth + 1;

        if (element.Node.LeftChild != null) {
          var left = new BTreeNodeInfo() {
            Node = element.Node.LeftChild,
            Depth = depth,
          };
          bufer.Enqueue(left);
        }
        if (element.Node.RightChild != null) {
          var right = new BTreeNodeInfo() {
            Node = element.Node.RightChild,
            Depth = depth,
          };
          bufer.Enqueue(right);
        }
      }

      return returnArray.ToArray();
    }
  }
}
