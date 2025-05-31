using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int scoreP1 ;
    public int scoreP2 ;
    
    public TextMeshProUGUI scoreTextP1;
    public TextMeshProUGUI scoreTextP2;
    
    
    private const string HighScoreKey = "HighScore";
    
    
    void Start()
    {
            GameObject personaje1 = GameObject.FindWithTag("Player1");
        GameObject personaje2 = GameObject.FindWithTag("Player2");

        scoreP1 = personaje1.GetComponent<PlayerScore>().score;
        scoreP2 = personaje2.GetComponent<PlayerScore>().score;

        Debug.Log("P1: " + scoreP1 + " | P2: " + scoreP2);
    }
    void Update()
    {
        // Actualiza los puntajes de los jugadores
        GameObject personaje1 = GameObject.FindWithTag("Player1");
        GameObject personaje2 = GameObject.FindWithTag("Player2");

        if (personaje1 != null)
            scoreP1 = personaje1.GetComponent<PlayerScore>().score;
        if (personaje2 != null)
            scoreP2 = personaje2.GetComponent<PlayerScore>().score;

        UpdateHighScore();
    }
    
    void FixedUpdate()
    {
        // Actualiza los textos de puntaje
        if (scoreTextP1 != null)
            scoreTextP1.text = "Jugador 1: " + scoreP1.ToString();
        if (scoreTextP2 != null)
            scoreTextP2.text = "Jugador 2: " + scoreP2.ToString();
    }
    void Awake()
    {
        // Singleton: se mantiene entre escenas
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetWinnerScore()
    {
        return Mathf.Max(scoreP1, scoreP2);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    private void UpdateHighScore()
    {
        int currentBest = Mathf.Max(scoreP1, scoreP2);
        if (currentBest > GetHighScore())
        {
            PlayerPrefs.SetInt(HighScoreKey, currentBest);
        }
    }

    
}