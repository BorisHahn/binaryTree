using System.Runtime.CompilerServices;

namespace binaryTree
{
    public enum Side
    {
        Left,
        Right
    }

    public class BinaryTreeNode<T> where T : ITuple
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public BinaryTreeNode<T> LeftNode { get; set; }
        public BinaryTreeNode<T> RightNode { get; set; }
        public BinaryTreeNode<T> ParentNode { get; set; }

        public Side? NodeSide =>
        ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
        ? Side.Left
                : Side.Right;

        public override string ToString() => Data.ToString();
    }
}
