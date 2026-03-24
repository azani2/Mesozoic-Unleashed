using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DinoSection : MonoBehaviour
{
    [SerializeField]
    private int dinoId;
    [SerializeField]
    private TextMeshProUGUI dinoName;
    [SerializeField]
    Button button;

    private void Awake()
    {
        button.onClick.AddListener(OpenInfoPage);
    }
    
    private void Start()
    {
        string dinoNameText = DinoManager.instance.GetDinoById(dinoId).animal;
        dinoName.text = dinoNameText;
    }

    private void OpenInfoPage()
    {
        UIManager.Instance.openDinoInfoPage(dinoId);
    }
}
