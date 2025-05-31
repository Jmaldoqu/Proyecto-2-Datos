using TreeEditor;
using UnityEngine;

public abstract class Tree 
{
    public abstract void Insert(int key);
    public abstract bool Search(int key);
    public abstract int GetDepth();
    public abstract string[] getNodesForVisuals(int challengeOption);
    public abstract void Clear();

}
