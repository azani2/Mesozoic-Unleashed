using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClosedChoiceGame : MonoBehaviour
{
    private int result = 0;

    public static ClosedChoiceGame instance;
    private int currentQuestion;
    private int totalQuestions;
    private Exercise[] exercises;

    [SerializeField]
    private Button option1Button;
    [SerializeField]
    private Button option2Button;
    [SerializeField]
    private Button option3Button;
    [SerializeField]
    private Button option4Button;

    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private TextMeshProUGUI wrongAnswerText;
    [SerializeField]
    private TextMeshProUGUI correctAnswerText;
    [SerializeField]
    private TextMeshProUGUI plusPoint;

    [SerializeField]
    private TextMeshProUGUI questionNumberText;
    [SerializeField]
    private TextMeshProUGUI questiionText;
    [SerializeField]
    private TextMeshProUGUI resultText;

    [SerializeField]
    private Sprite correctOptionBackground;
    [SerializeField]
    private Sprite defaultOptionBackground;

    private void Awake()
    {
        instance = this;
    }

    private Exercise CurrentExercise()
    {
        return instance.exercises[instance.currentQuestion - 1];
    }

    private void Start()
    {
        GameEvents.current.onMakeExerciseSet += PlayChoiceGame;
        exitButton.onClick.AddListener(ExitSession);
        option1Button.onClick.AddListener(ClickedOption1);
        option2Button.onClick.AddListener(ClickedOption2);
        option3Button.onClick.AddListener(ClickedOption3);
        option4Button.onClick.AddListener(ClickedOption4);
        nextButton.onClick.AddListener(CompleteQuestion);

        nextButton.gameObject.SetActive(false);
        wrongAnswerText.gameObject.SetActive(false);
        correctAnswerText.gameObject.SetActive(false);
    }

    private void LoadQuestion()
    {
        instance.currentQuestion++;
        if(instance.currentQuestion > instance.totalQuestions)
        {
            GameEvents.current.FinalizePracticeResult(instance.result, instance.totalQuestions);
            UIManager.Instance.openPracticeResults();
            return;
        }
        questionNumberText.text = instance.currentQuestion + "/" + instance.totalQuestions;
        questiionText.text = CurrentExercise().question;
        resultText.text = instance.result + " pts.";
        option1Button.GetComponentInChildren<TMP_Text>().text = CurrentExercise().options[0];
        option2Button.GetComponentInChildren<TMP_Text>().text = CurrentExercise().options[1];
        option3Button.GetComponentInChildren<TMP_Text>().text = CurrentExercise().options[2];
        option4Button.GetComponentInChildren<TMP_Text>().text = CurrentExercise().options[3];
        option1Button.image.sprite = defaultOptionBackground;
        option2Button.image.sprite = defaultOptionBackground;
        option3Button.image.sprite = defaultOptionBackground;
        option4Button.image.sprite = defaultOptionBackground;
        nextButton.gameObject.SetActive(false);
        wrongAnswerText.gameObject.SetActive(false);
        correctAnswerText.gameObject.SetActive(false);
        plusPoint.gameObject.SetActive(false);
        option1Button.interactable = true;
        option2Button.interactable = true;
        option3Button.interactable = true;
        option4Button.interactable = true;
    }

    private void PlayChoiceGame()
    {
        instance.exercises = ExerciseCreator.instance.exerciseSet.exercises;
        instance.result = 0;
        instance.currentQuestion = 0;
        instance.totalQuestions = instance.exercises.Length;
        LoadQuestion();
    }

    private int getCurrentCorrectOption()
    {
        return CurrentExercise().correctIdx;
    }

    private bool isAlternativeAnswer(int opt)
    {
        return CurrentExercise().alternatives[opt];
    }

    private void CheckOptionCorrect(int opt)
    {
        bool correct = (getCurrentCorrectOption() == opt || isAlternativeAnswer(opt));
        result += correct ? 1 : 0;
        resultText.text = result + " pts.";
        if (correct)
        {
            plusPoint.gameObject.SetActive(true);
            correctAnswerText.gameObject.SetActive(true);
        }
        else
        {
            wrongAnswerText.gameObject.SetActive(true);
        }
        RevealAnswer();
    }

    private void ClickedOption1()
    {
        CheckOptionCorrect(0);
    }

    private void ClickedOption2()
    {
        CheckOptionCorrect(1);
    }

    private void ClickedOption3()
    {
        CheckOptionCorrect(2);
    }

    private void ClickedOption4()
    {
        CheckOptionCorrect(3);
    }

    private void CompleteQuestion()
    {
        LoadQuestion();
    }

    private void RevealAnswer()
    {
        nextButton.gameObject.SetActive(true);
        option1Button.interactable = false;
        option2Button.interactable = false;
        option3Button.interactable = false;
        option4Button.interactable = false;
        switch (getCurrentCorrectOption())
        {
            case 0: { option1Button.image.sprite = correctOptionBackground; break; }
            case 1: { option2Button.image.sprite = correctOptionBackground; break; }
            case 2: { option3Button.image.sprite = correctOptionBackground; break; }
            case 3: { option4Button.image.sprite = correctOptionBackground; break; }
            default: { break; }
        }
    }

    private void ExitSession()
    {
        instance.currentQuestion = 0;
        instance.result = 0;
        UIManager.Instance.openPracticeCreation();
    }
}
