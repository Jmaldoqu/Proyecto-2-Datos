using UnityEngine;

public class BSTTreeNode
{
    public int key;
    public BSTTreeNode left;
    public BSTTreeNode right;

    public BSTTreeNode(int value) {

        key = value;
        left = null;
        right = null;
    }
}
