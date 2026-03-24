using UnityEngine;
using System.IO;

public class InteractableDialogue : MonoBehaviour
{
    public string dialogueFileNameFirst; // Without .json
    public string dialogueFileNameSeen;
    public DialogueDisplay dialogueDisplay;
    bool seen_dialogue;

    private void OnMouseDown()
    {
        LoadAndDisplayDialogue();
    }

    void LoadAndDisplayDialogue()
    {
        string lang = LanguageManager.Instance.selectedLanguage;

        if (!seen_dialogue)
        {
            seen_dialogue = true;
            TextAsset jsonFile = Resources.Load<TextAsset>($"Dialogues/{dialogueFileNameFirst}_{lang}");
            if (jsonFile != null)
            {
                DialogueData dialogue = JsonUtility.FromJson<DialogueData>(jsonFile.text);
                dialogueDisplay.StartDialogue(dialogue.lines);

            }
            else
            {
                Debug.LogError("Dialogue file not found:" + dialogueFileNameFirst + "_" + lang);
            }
        }

        else
        {
            TextAsset jsonFile = Resources.Load<TextAsset>($"Dialogues/{dialogueFileNameSeen}_{lang}");
            if (jsonFile != null)
            {
                DialogueData dialogue = JsonUtility.FromJson<DialogueData>(jsonFile.text);
                dialogueDisplay.StartDialogue(dialogue.lines);

            }
            else
            {
                Debug.LogError("Dialogue file not found:" + dialogueFileNameSeen + "_" + lang);
            }

        }
    }
}
