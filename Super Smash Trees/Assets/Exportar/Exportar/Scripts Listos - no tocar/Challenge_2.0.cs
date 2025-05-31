using System;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Challenge_2 : MonoBehaviour
{

    public Tree ChallengeTree;

    public string TreeType;
    public int challengeOption;

    public GameObject TreeVisual;
    public GameObject TreeVisual_Selected;
    public GameObject[] TreeVisual_Options;

    public int playerNum;
    public int powerUp;

    public Vector3 spawnPosition;
    public Quaternion spawnRotation;

    void Start()
    {
        StartChallenge();
    }

    void Update()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        playerMovement.GetPowers(powerUp);
    }
    
    

    private void StartChallenge()
    {


        if (playerNum == 1)
        {
            spawnPosition = new Vector3(-6.4f, -0.7f, 0);
            spawnRotation = Quaternion.identity;
        }
        else {

            spawnPosition = new Vector3(5.4f, -0.7f, 0);
            spawnRotation = Quaternion.identity;

        }

        string[] typesOfTrees = { "BST", "AVL", "B" };
        challengeOption = UnityEngine.Random.Range(0, 2);
        TreeType = typesOfTrees[UnityEngine.Random.Range(0, typesOfTrees.Length)];

        TreeType = "BST";

        if (TreeType == "BST")
        {

            ChallengeTree = new BSTTree1();

            TreeVisual = Instantiate(TreeVisual_Options[0], spawnPosition, spawnRotation);
            BSTTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BSTTreeVisualChallenge1>();
            visualScript.TransparentNodes();
        }

        if (TreeType == "AVL")
        {

            ChallengeTree = new AVLTree1();

            TreeVisual = Instantiate(TreeVisual_Options[0], spawnPosition, spawnRotation);
            BSTTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BSTTreeVisualChallenge1>();
            visualScript.TransparentNodes();

        }

        if (TreeType == "B")
        {

            Vector3 position;
            Quaternion rotation;

            if (playerNum == 1)
            {
                position = new Vector3(-7.1f, 3.5f, 0);
                rotation = Quaternion.identity;
            }
            else
            {

                position = new Vector3(5.6f, 3.5f, 0); //Corrgir para player 2
                rotation = Quaternion.identity;
            }


            ChallengeTree = new BTree1(2);

            TreeVisual = Instantiate(TreeVisual_Options[1], position, rotation);
            BTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BTreeVisualChallenge1>();
            visualScript.TransparentNodes();


        }


    }

    public void InsertInTree(int key)
    {
        if (ChallengeTree == null)
        {
            Debug.LogError("ChallengeTree es null.");
        }

        ChallengeTree.Insert(key);

        if ((TreeType == "BST" || TreeType == "AVL") && TreeVisual != null)
        {
            BSTTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BSTTreeVisualChallenge1>();
            string[] nodes = ChallengeTree.getNodesForVisuals(challengeOption);
            visualScript.NodesVisualActualization(2, nodes);
        }

        if ((TreeType == "B") && TreeVisual != null)
        {
            BTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BTreeVisualChallenge1>();
            string[] nodes = ChallengeTree.getNodesForVisuals(challengeOption);
            Debug.Log(nodes.Length);
            visualScript.NodesVisualActualization(2, nodes);
        }

        if (isChallengeComplete())
        {
            
            if (TreeType == "BST" && challengeOption == 0) { powerUp = 1; RestartChallenge();}
            if (TreeType == "BST" && challengeOption == 1) { powerUp = 2; RestartChallenge(); }
            if (TreeType == "AVL" && challengeOption == 0) { powerUp = 3; RestartChallenge(); }
            if (TreeType == "AVL" && challengeOption == 1) { powerUp = 4; RestartChallenge(); }
            if (TreeType == "B" && challengeOption == 0) { powerUp = 5; RestartChallenge(); }
            if (TreeType == "B" && challengeOption == 1) { powerUp = 6; RestartChallenge(); }

        }
        

    }

    public void RestartChallenge()
    {

        ChallengeTree.Clear();

        if (TreeType == "BST" || TreeType == "AVL")
        {

            BSTTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BSTTreeVisualChallenge1>();
            visualScript.TransparentNodes();
        }

        if (TreeType == "B")
        {

            BTreeVisualChallenge1 visualScript = TreeVisual.GetComponent<BTreeVisualChallenge1>();
            visualScript.TransparentNodes();
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
        if (TreeType == "B" && challengeOption == 0 && depth == 1) return true;
        if (TreeType == "B" && challengeOption == 1 && depth == 1) return true;

        return false;
    }

}