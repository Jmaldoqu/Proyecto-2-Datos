using System.Collections.Generic;

public class BTreeNode
{
    public List<int> keys;
    public List<BTreeNode> children;
    public bool isLeaf;
    private int t;

    public BTreeNode(int t, bool isLeaf)
    {
        this.t = t;
        this.isLeaf = isLeaf;
        keys = new List<int>();
        children = new List<BTreeNode>();
    }

    public bool Search(int key)
    {
        int i = 0;
        while (i < keys.Count && key > keys[i]) i++;

        if (i < keys.Count && keys[i] == key)
            return true;

        if (isLeaf)
            return false;

        return children[i].Search(key);
    }

    public void InsertNonFull(int key)
    {
        int i = keys.Count - 1;

        if (isLeaf)
        {
            keys.Add(0); // Agregamos espacio
            while (i >= 0 && key < keys[i])
            {
                keys[i + 1] = keys[i];
                i--;
            }
            keys[i + 1] = key;
        }
        else
        {
            while (i >= 0 && key < keys[i]) i--;
            i++;
            if (children[i].keys.Count == 2 * t - 1)
            {
                SplitChild(i, children[i]);
                if (key > keys[i])
                    i++;
            }
            children[i].InsertNonFull(key);
        }
    }

    public void SplitChild(int i, BTreeNode y)
    {
        BTreeNode z = new BTreeNode(t, y.isLeaf);

        // z recibe las últimas t-1 claves de y
        for (int j = 0; j < t - 1; j++)
            z.keys.Add(y.keys[j + t]);

        // Si y no es hoja, z recibe sus últimos t hijos
        if (!y.isLeaf)
        {
            for (int j = 0; j < t; j++)
                z.children.Add(y.children[j + t]);

            y.children.RemoveRange(t, t);
        }

        // y pierde las claves e hijos que fueron pasados
        y.keys.RemoveRange(t, t - 1); // t-1 claves
        y.keys.RemoveAt(t - 1);       // clave del medio

        children.Insert(i + 1, z);
        keys.Insert(i, y.keys[t - 1]);
    }
}
