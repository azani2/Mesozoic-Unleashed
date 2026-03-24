using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    public string selectedLanguage = "en";
    public string selectedDifficulty = "easy";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLanguage(string language)
    {
        selectedLanguage = language;
        Instance.selectedLanguage = language;
        Debug.Log("Language set to: " + language);
    }

    public void SetDifficulty(string difficulty)
    {
        selectedDifficulty = difficulty;
        Instance.selectedDifficulty = difficulty;
        Debug.Log("Difficulty set to: " + difficulty);
    }
}
