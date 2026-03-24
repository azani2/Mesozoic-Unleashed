using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour
{
    public static ResultDisplay Instance;
    private bool resultDisplayed = false;
    private int result;
    private int total;

    [SerializeField]
    private TextMeshProUGUI resultText;
    [SerializeField]
    private TextMeshProUGUI totalText;

    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button dataBaseButton;
    [SerializeField]
    private Button mainMenuButton;

    [SerializeField]
    private GameObject thisPanel; 

    void Start()
    {
        GameEvents.current.onPracticeResultFinal += DisplayResult;
        dataBaseButton.onClick.AddListener(GoToDatabase);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        backButton.onClick.AddListener(GoToPracticeCreation);
    }

    private void DisplayResult(int result, int total)
    {
        Debug.Log(result + ", " + total);
        Instance.result = result;
        Instance.total = total;
        resultText.text = result + "";
        totalText.text = "/" + total;
        resultDisplayed = true;
    }

    private void GoToDatabase()
    {
        UIManager.Instance.openDatabase();
    }

    private void GoToMainMenu()
    {
        UIManager.Instance.openMainMenu();
    }

    private void GoToPracticeCreation()
    {
        UIManager.Instance.openPracticeCreation();
    }
}
