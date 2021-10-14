namespace lesson4.BinaryTree
{
    public class BTreeNode
    {
        public int Value { get; set; }
        public BTreeNode LeftChild { get; set; }
        public BTreeNode RightChild { get; set; }
        public BTreeNode Parent { get; set; }
        public override bool Equals(object obj) {
            var node = obj as BTreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
        public override int GetHashCode() {
            throw new System.NotImplementedException();
        }
    }
}
