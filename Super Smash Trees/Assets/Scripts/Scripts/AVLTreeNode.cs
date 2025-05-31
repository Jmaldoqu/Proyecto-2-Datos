public class AVLTreeNode
{
    public int key;
    public AVLTreeNode left, right;
    public int height;

    public AVLTreeNode(int key)
    {
        this.key = key;
        height = 1;
    }
}
