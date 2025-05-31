using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FadeAndLoad : MonoBehaviour
{
    public float totalTime = 300f; // 5 minutos
    public TextMeshProUGUI timerText;
    public string sceneToLoad = "NombreDeLaEscena";
    public Image blackScreen;
    public float fadeDuration = 2f; // segundos

    private float timeRemaining;
    private bool isFading = false;

    void Start()
    {
        timeRemaining = totalTime;
        blackScreen.color = new Color(0, 0, 0, 0); // asegurar transparente
    }

    void Update()
    {
        if (isFading) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
        }
        else
        {
            timerText.enabled = false;
            StartCoroutine(FadeToBlack());
            isFading = true;
        }
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    System.Collections.IEnumerator FadeToBlack()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        
        
        
        
        SceneManager.LoadScene(sceneToLoad);
    }
}