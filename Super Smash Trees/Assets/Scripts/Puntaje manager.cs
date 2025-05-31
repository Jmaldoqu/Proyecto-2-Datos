using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;

    public void AddPoints(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }
}