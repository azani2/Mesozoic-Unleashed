using UnityEngine;
using UnityEngine.UI;

public class DatabaseMain : MonoBehaviour
{
    [SerializeField]
    Button button;

    private void Awake()
    {
        button.onClick.AddListener(GoBackToMainMenu);
    }

    private void GoBackToMainMenu()
    {
        UIManager.Instance.openMainMenu();
    }
}
