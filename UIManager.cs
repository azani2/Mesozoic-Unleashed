using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private GameObject currentScreen;

    [SerializeField]
    private GameObject mainMenuScreen;
    [SerializeField]
    private GameObject databaseMainScreen;
    [SerializeField]
    private GameObject dinoInfoScreen;
    [SerializeField]
    private GameObject dinoEnvironmentScreen;
    [SerializeField]
    private GameObject dinoAnatomyScreen;
    [SerializeField]
    private GameObject createExerciseScreen;
    [SerializeField]
    private GameObject exerciseScreen;
    [SerializeField]
    private GameObject practiceResultScreen;

    private void Awake()
    {
        Instance = this;
        currentScreen = mainMenuScreen;
    }

    private void Start()
    {
        currentScreen.SetActive(true);
        databaseMainScreen.SetActive(false);
        dinoInfoScreen.SetActive(false);
        dinoEnvironmentScreen.SetActive(false);
        dinoAnatomyScreen.SetActive(false);
        createExerciseScreen.SetActive(false);
        exerciseScreen.SetActive(false);
        practiceResultScreen.SetActive(false);
    }

    public void openMainMenu()
    {
        currentScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        currentScreen = mainMenuScreen;
        Debug.Log("Current Screen: " +  currentScreen.name);
    }

    public void openDinoInfoPage(int dinoId)
    {
        currentScreen.SetActive(false);
        dinoInfoScreen.SetActive(true);
        currentScreen = dinoInfoScreen;
        GameEvents.current.OpenDinoPage(dinoId);
    }

    public void openDatabase()
    {
        currentScreen.SetActive(false);
        databaseMainScreen.SetActive(true);
        currentScreen = databaseMainScreen;
    }

    public void openDinoAnatomy()
    {
        currentScreen.SetActive(false);
        dinoAnatomyScreen.SetActive(true);
        currentScreen = dinoAnatomyScreen;
    }

    public void openPracticeCreation()
    {
        currentScreen.SetActive(false);
        createExerciseScreen.SetActive(true);
        currentScreen = createExerciseScreen;
    }

    public void openPractice()
    {
        currentScreen.SetActive(false);
        exerciseScreen.SetActive(true);
        currentScreen = exerciseScreen;
    }

    public void openPracticeResults()
    {
        currentScreen.SetActive(false);
        practiceResultScreen.SetActive(true);
        currentScreen = practiceResultScreen;
    }

    public void openEnvironmentScreen(int dinoId)
    {
        currentScreen.SetActive(false);
        dinoEnvironmentScreen.SetActive(true);
        currentScreen = dinoEnvironmentScreen;
        GameEvents.current.OpenEnvPage(dinoId);
    }

    public void openAnatomyScreen(int dinoId)
    {
        currentScreen.SetActive(false);
        dinoAnatomyScreen.SetActive(true);
        currentScreen = dinoAnatomyScreen;
        GameEvents.current.OpenAnatomyPage(dinoId);
    }
}
