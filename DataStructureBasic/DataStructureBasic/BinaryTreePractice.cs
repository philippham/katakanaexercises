namespace DataStructureBasic
{
    public class NodeForBinaryTree
    {
        public NodeForBinaryTree(int data, NodeForBinaryTree left, NodeForBinaryTree right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public int Data { get; set; }
        public NodeForBinaryTree Left { get; set; }
        public NodeForBinaryTree Right { get; set; }
    }

    public class BinaryTreeOperations
    {
        public NodeForBinaryTree Root { get; private set; }

        public void SetRoot(NodeForBinaryTree root)
        {
            Root = root;
        }

        public NodeForBinaryTree Find(NodeForBinaryTree current, int lookUpData)
        {
            while (true)
            {
                if (current == null)
                    return null;

                if (current.Data == lookUpData)
                    return current;

                if (lookUpData > current.Data)
                {
                    current = current.Right;
                    continue;
                }

                current = current.Left;
            }
        }

        public bool Remove(int dataNeedToRemove)
        {
            var parentOfNodeNeedsToRemove = FindParent(dataNeedToRemove);
            
            if (parentOfNodeNeedsToRemove != null)
            {
                var nodeNeedsToRemove = Find(parentOfNodeNeedsToRemove, dataNeedToRemove);

                // If Remove Node has Right
                // re -reference Parent of Remove Node to Remove node's left child
                if (nodeNeedsToRemove.Right == null)
                {
                    if (dataNeedToRemove >= parentOfNodeNeedsToRemove.Data)
                        parentOfNodeNeedsToRemove.Right = nodeNeedsToRemove.Left;
                    else
                        parentOfNodeNeedsToRemove.Left = nodeNeedsToRemove.Left;
                }
                else
                {
                    if (nodeNeedsToRemove.Right.Left == null)
                    {
                        nodeNeedsToRemove.Right.Left = nodeNeedsToRemove.Left;

                        if (nodeNeedsToRemove.Right.Left.Data >= parentOfNodeNeedsToRemove.Data)
                            parentOfNodeNeedsToRemove.Right = nodeNeedsToRemove.Right.Left;
                        else
                            parentOfNodeNeedsToRemove.Left = nodeNeedsToRemove.Right.Left;
                    }
                    else
                    {
                        var leftMostChild = FindLeftMostChild(nodeNeedsToRemove);
                        var parentOfTheLeftMostChild = FindParent(leftMostChild.Data);
                        parentOfTheLeftMostChild.Left = null;
                        leftMostChild.Left = nodeNeedsToRemove.Left;

                        if (leftMostChild.Data >= parentOfNodeNeedsToRemove.Data)
                            parentOfNodeNeedsToRemove.Right = leftMostChild;
                        else
                            parentOfNodeNeedsToRemove.Left = leftMostChild;

                        if (leftMostChild.Right != null)
                            leftMostChild.Right.Right = parentOfTheLeftMostChild;
                        else
                            leftMostChild.Right = parentOfTheLeftMostChild;
                    }
                }
                return true;
            }

            Root = null;
            return false;
        }

        private static NodeForBinaryTree FindLeftMostChild(NodeForBinaryTree current)
        {
            while (true)
            {
                if (current.Left == null) return current;
                current = current.Left;
            }
        }

        private NodeForBinaryTree FindParent(int lookUpData)
        {
            var current = Root;
            NodeForBinaryTree parent = null;
            while (current != null)
            {
                if (current.Data == lookUpData)
                    break;

                if (lookUpData > current.Data)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (lookUpData < current.Data)
                {
                    parent = current;
                    current = current.Left;
                }
            }
            return parent;
        }
    }
}
