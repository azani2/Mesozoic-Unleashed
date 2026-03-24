using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DinoDisplay : MonoBehaviour
{
    static private int currenDinoId;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI modernNameText;
    [SerializeField]
    private TextMeshProUGUI nameMeaningText;
    [SerializeField]
    private TextMeshProUGUI periodText;
    [SerializeField]
    private TextMeshProUGUI epochText;
    [SerializeField]
    private TextMeshProUGUI heightText;
    [SerializeField]
    private TextMeshProUGUI weightText;
    [SerializeField]
    private TextMeshProUGUI extinctionText;

    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button environmentButton;
    [SerializeField]
    private Button anatomyButton;

    public void Populate(DinoData dino)
    {
        Debug.Log("Begin Populate.");
        currenDinoId = dino.id - 1;
        nameText.text = dino.animal;
        modernNameText.text = dino.common_name;
        nameMeaningText.text = dino.name_meaning;
        periodText.text = dino.period;
        epochText.text = dino.epoch;
        heightText.text = dino.height;
        weightText.text = dino.weight;
        extinctionText.text = dino.extinction_event + "\n" + dino.extinction;
    }

    void Awake()
    {
        GameEvents.current.onOpenDinoPage += ShowPage;
        backButton.onClick.AddListener(GoBackToDatabase);
        environmentButton.onClick.AddListener(OpenEnvironmentScreen);
        anatomyButton.onClick.AddListener(OpenAnatomyScreen);
    }

    void ShowPage(int dinoId)
    {
        Debug.Log("Showing Dino Page.");
        Populate(DinoManager.instance.GetDinoById(dinoId));
    }

    void GoBackToDatabase()
    {
        UIManager.Instance.openDatabase();
    }

    void OpenEnvironmentScreen()
    {
        UIManager.Instance.openEnvironmentScreen(currenDinoId);
    }

    void OpenAnatomyScreen()
    {
        UIManager.Instance.openAnatomyScreen(currenDinoId);
    }
}
