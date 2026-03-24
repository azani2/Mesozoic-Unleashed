using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnatomyDisplay : MonoBehaviour
{
    private static int dinoId;

    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button dinoInfoButton;
    [SerializeField]
    private Button envButton;

    [SerializeField]
    private TextMeshProUGUI dinoNameText;
    [SerializeField]
    private TextMeshProUGUI anatomyText;

    private void Awake()
    {
        dinoInfoButton.onClick.AddListener(GoToDinoInfo);
        backButton.onClick.AddListener(GoToDatabase);
        envButton.onClick.AddListener(GoToEnvironment);
    }

    private void Start()
    {
        GameEvents.current.onOpenAnatomyPage += ShowInfo;
    }

    private void Populate(DinoData dino)
    {
        anatomyText.text = dino.physical_characteristics;
        dinoNameText.text = dino.animal;
    }

    private void ShowInfo(int id)
    {
        Debug.Log("Showing anatomy.");
        dinoId = id;
        Populate(DinoManager.instance.GetDinoById(dinoId));
    }

    private void GoToDinoInfo()
    {
        UIManager.Instance.openDinoInfoPage(dinoId);
    }

    private void GoToDatabase()
    {
        UIManager.Instance.openDatabase();
    }

    private void GoToEnvironment()
    {
        UIManager.Instance.openEnvironmentScreen(dinoId);
    }
}
