using System.Runtime.CompilerServices;

namespace binaryTree
{
    public class BinaryTree<T> where T : ITuple
    {
        public BinaryTreeNode<T> RootNode { get; set; }

        public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }
            currentNode = currentNode ?? RootNode;

            var val = (int?)node.Data[1] ?? 0;
            var currentVal = (int?)currentNode?.Data[1] ?? 0;

            node.ParentNode = currentNode;
            int result;
            return (result = val.CompareTo(currentVal)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }
        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }

        public void PrintTree()
        {
            PrintTree(RootNode);
        }

        private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
                indent += new string(' ', 3);
                PrintTree(startNode.LeftNode, indent, Side.Left);
                PrintTree(startNode.RightNode, indent,Side.Right);
            }
        }

        public void InOrderTraversal(BinaryTreeNode<T> startNode, Action<string, int> action)
        {
            if (startNode != null)
            {
                InOrderTraversal(startNode.LeftNode, action);
                action((string?)startNode.Data[0] ?? "",(int?)startNode.Data[1] ?? 0);
                InOrderTraversal(startNode.RightNode, action);
            }
        }

        public BinaryTreeNode<T> FindNode(int data, BinaryTreeNode<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            
            var currentVal = (int?)startWithNode.Data[1] ?? 0;

            return (result = data.CompareTo(currentVal)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }
    }
}
