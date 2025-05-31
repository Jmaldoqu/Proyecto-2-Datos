using UnityEngine;
using TMPro;

public class ShowFinalScore : MonoBehaviour
{
    public TextMeshProUGUI winnerScoreText;
    public TextMeshProUGUI loserScoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        if (ScoreManager.Instance == null)
        {
            Debug.LogWarning("No se encontró el ScoreManager.");
            return;
        }

        int scoreP1 = ScoreManager.Instance.scoreP1;
        int scoreP2 = ScoreManager.Instance.scoreP2;
        int highScore = ScoreManager.Instance.GetHighScore();

        if (scoreP1 >= scoreP2)
        {
            winnerScoreText.text = $"Ganador: Personaje 1 ({scoreP1} pts)";
            loserScoreText.text  = $"Perdedor: Personaje 2 ({scoreP2} pts)";
        }
        else
        {
            winnerScoreText.text = $"Ganador: Personaje 2 ({scoreP2} pts)";
            loserScoreText.text  = $"Perdedor: Personaje 1 ({scoreP1} pts)";
        }

        if (highScoreText != null)
            highScoreText.text = $"Récord histórico: {highScore} pts";
    }
}
