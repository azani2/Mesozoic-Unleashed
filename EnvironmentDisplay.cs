using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentDisplay : MonoBehaviour
{
    private static int dinoId;

    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button dinoInfoButton;
    [SerializeField]
    private Button anatomyButton;

    [SerializeField]
    private TextMeshProUGUI dinoNameText;
    [SerializeField]
    private TextMeshProUGUI habitatText;
    [SerializeField]
    private TextMeshProUGUI areaText;
    [SerializeField]
    private TextMeshProUGUI climateText;


    public void Populate(DinoData dino)
    {
        Debug.Log("Begin Populate Environment.");
        dinoNameText.text = dino.animal;
        habitatText.text = dino.environment;
        areaText.text = dino.area;
        climateText.text = dino.climate;
    }

    private void Awake()
    {
        Debug.Log("Environment Screen Awake.");
        dinoInfoButton.onClick.AddListener(GoToDinoInfo);
        backButton.onClick.AddListener(GoToDatabase);
        anatomyButton.onClick.AddListener(GoToAnatomy);
    }

    private void Start()
    {
        GameEvents.current.onOpenEnvPage += ShowInfo;
    }

    private void ShowInfo(int id)
    {
        Debug.Log("Showing environment.");
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

    private void GoToAnatomy()
    {
        UIManager.Instance.openAnatomyScreen(dinoId);
    }
}
