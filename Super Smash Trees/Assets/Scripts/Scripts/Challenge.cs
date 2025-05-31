using UnityEngine;

public class Challenge : MonoBehaviour
{
    public Tree ChallengeTree;
    public string TreeType;
    public GameObject[] TreeVisualsOptions;
    public GameObject TreeVisual;
    public int counter;
    public int challengeOption;

    private void Start()
    {
        StartChallenge();
    }

    private void StartChallenge()
    {
        string[] types = { "BST", "AVL", "B" };

        challengeOption = Random.Range(0, 2); // 0 o 1
        TreeType = types[Random.Range(0, types.Length)];

        if (TreeType == "BST")
        {
            ChallengeTree = new BSTTree1();

            if (challengeOption == 0)
            {
                TreeVisual = TreeVisualsOptions[0];
                BSTTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BSTTreeVisualChallenge1>();
                visualScript.TransparentNodes();
            }
            else if (challengeOption == 1)
            {
                //TreeVisual = TreeVisualsOptions[1];
                //BSTTreeVisualChallenge2 visualScript = TreeVisual.GetComponent<BSTTreeVisualChallenge1>();
                //visualScript.TransparentNodes();
            }
        }
        else if (TreeType == "AVL")
        {
            ChallengeTree = new AVLTree1();

            if (challengeOption == 0)
            {
                //TreeVisual = TreeVisualsOptions[2];
                //AVLTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<AVLTreeVisualChallenge1>();
                //visualScript.TransparentNodes();
            }
            else if (challengeOption == 1)
            {
                //TreeVisual = TreeVisualsOptions[3];
                //AVLTreeVisualChallenge2 visualScript = TreeVisual.GetComponent<AVLTreeVisualChallenge2>();
                //visualScript.TransparentNodes();
            }
        }
        else if (TreeType == "B")
        {
            ChallengeTree = new BTree1();

            if (challengeOption == 0)
            {
                //TreeVisual = TreeVisualsOptions[4];
                //BTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BTreeVisualChallenge1>();
                //visualScript.TransparentNodes();
            }
            else if (challengeOption == 1)
            {
                //TreeVisual = TreeVisualsOptions[5];
                //BTreeVisualChallenge2 visualScript = TreeVisual.GetComponent<BTreeVisualChallenge2>();
                //visualScript.TransparentNodes();
            }
        }
        else
        {
            Debug.LogError("Tipo de árbol desconocido.");
        }

        Debug.Log($"Nuevo reto: Árbol = {TreeType}, Opción = {challengeOption}");
    }

    public void InsertInTree(int key)
    {
        if (ChallengeTree == null)
        {
            Debug.LogError("ChallengeTree es null.");
            return;
        }

        ChallengeTree.Insert(key);

        if (TreeType == "BST" && challengeOption == 0 && TreeVisual != null)
        {
            BSTTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BSTTreeVisualChallenge1>();
            visualScript.TransparentNodes();
            visualScript.NodesVisualActualization(2, new int[] { 1, 2, 3 }); // Placeholder
        }

        if (isChallengeComplete())
        {
            Debug.Log("¡Reto completado!");
            RestartChallenge();
        }
    }

    public void RestartChallenge()
    {
        // Limpia tokens si es necesario
        string[] tokenTags = { "BSTTokenTag", "AVLTokenTag", "BTokenTag" };
        foreach (string tag in tokenTags)
        {
            GameObject[] tokens = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject token in tokens)
            {
                Destroy(token);
            }
        }

        ChallengeTree = null;
        TreeVisual = null;

        StartChallenge();
    }

    public bool isChallengeComplete()
    {
        int depth = ChallengeTree.GetDepth();

        if (TreeType == "BST" && challengeOption == 0 && depth == 3) return true;
        if (TreeType == "BST" && challengeOption == 1 && depth == 4) return true;
        if (TreeType == "AVL" && challengeOption == 0 && depth == 3) return true;
        if (TreeType == "AVL" && challengeOption == 1 && depth == 4) return true;
        if (TreeType == "B" && challengeOption == 0 && depth == 3) return true;
        if (TreeType == "B" && challengeOption == 1 && depth == 4) return true;

        return false;
    }

    private void Update()
    {
        
    }
}
