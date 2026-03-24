using UnityEngine;

public class start_game : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnConfirmChoices()
    {

        string lang = LanguageManager.Instance.selectedLanguage;
        string diff = LanguageManager.Instance.selectedDifficulty;

        Debug.Log($"Starting game with {lang} / {diff}");

        // Load game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Corridor");
    }

}
