using TMPro;
using UnityEngine;

public class DialogueDisplay : MonoBehaviour
{
    public TextMeshProUGUI speakerText;         // Reference to the speaker name TMP text
    public TextMeshProUGUI dialogueText;        // Reference to the dialogue body TMP text
    public GameObject dialoguePanel;

    private DialogueLine[] lines;
    private int currentLine = 0;
    private bool isDialogueActive = false;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(DialogueLine[] dialogueLines)
    {
        lines = dialogueLines;
        currentLine = 0;
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        ShowCurrentLine();
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
            if (currentLine < lines.Length)
            {
                ShowCurrentLine();
            }
            else
            {
                EndDialogue();
            }
        }
    }

    void ShowCurrentLine()
    {
        speakerText.text = lines[currentLine].speaker;
        dialogueText.text = lines[currentLine].text;
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }
}
