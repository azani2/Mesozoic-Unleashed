using UnityEngine;
using UnityEngine.UI;

public class ToggleGroup : MonoBehaviour
{
    public Button lang_option1Button;
    public Button lang_option2Button;

    public string lang_option1Value;
    public string lang_option2Value;

    public Button diff_option1Button;
    public Button diff_option2Button;

    public string diff_option1Value;
    public string diff_option2Value;

    public bool isLanguageGroup = true; // True = language, false = difficulty

    public Color activeColor = Color.white;
    public Color inactiveColor = Color.grey;

    private void Start()
    {
        LangSetActiveOption(lang_option1Button, lang_option1Value); // Default selection
        DiffSetActiveOption(diff_option1Button, diff_option1Value); // Default selection
    }

    public void LangOnOption1Clicked()
    {
        LangSetActiveOption(lang_option1Button, lang_option1Value);
    }

    public void LangOnOption2Clicked()
    {
        LangSetActiveOption(lang_option2Button, lang_option2Value);
    }

    private void LangSetActiveOption(Button selectedButton, string value)
    {
        UpdateVisual(lang_option1Button, selectedButton == lang_option1Button);
        UpdateVisual(lang_option2Button, selectedButton == lang_option2Button);

        if (isLanguageGroup)
            LanguageManager.Instance.SetLanguage(value);
        else
            LanguageManager.Instance.SetDifficulty(value);
    }

    public void DiffOnOption1Clicked()
    {
        DiffSetActiveOption(diff_option1Button, diff_option1Value);
    }

    public void DiffOnOption2Clicked()
    {
        DiffSetActiveOption(diff_option2Button, diff_option2Value);
    }

    private void DiffSetActiveOption(Button selectedButton, string value)
    {
        UpdateVisual(diff_option1Button, selectedButton == diff_option1Button);
        UpdateVisual(diff_option2Button, selectedButton == diff_option2Button);

        if (isLanguageGroup)
            LanguageManager.Instance.SetLanguage(value);
        else
            LanguageManager.Instance.SetDifficulty(value);
    }

    private void UpdateVisual(Button button, bool active)
    {
        Image img = button.GetComponent<Image>();
        if (img != null)
            img.color = active ? activeColor : inactiveColor;
    }
}
