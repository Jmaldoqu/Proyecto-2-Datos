public class BTreeNode
{
    public int NumKeys { get; set; }
    public int[] keys { get; set; }
    public BTreeNode[] children { get; set; }
    public bool IsLeaf { get; set; }

    public BTreeNode(bool isLeaf, int M)
    {
        IsLeaf = isLeaf;
        keys = new int[M - 1];
        children = new BTreeNode[M];
        NumKeys = 0;
    }
}