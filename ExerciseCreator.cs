using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Exercise
{
    int type;
    string typeName;
    int dinoId;
    
    public int correctIdx;
    public bool[] alternatives;
    public string[] options;
    public string correct;
    public string question;

    private int GenerateRandomDinoIndex(int firstExcluded, int secondExcluded, int thirdExcluded)
    {
        int r = -1;
        while (r < 0 ||  r == firstExcluded ||
            r == secondExcluded || r == thirdExcluded)
        {
            r = UnityEngine.Random.Range(0, 9);
        }
        return r;
    }

    public Exercise(int type, string typeName, int dinoId)
    {
        this.dinoId = dinoId;
        this.type = type;
        this.typeName = typeName;
        DinoData dino = DinoManager.instance.GetDinoById(dinoId);

        this.question = "What is the " + typeName + " of a " + dino.animal + "?";
        this.correct = dino.getCharacteristicByIdx(type);
        this.alternatives = new bool[4] {false, false, false, false};

        //Populate answer options
        this.correctIdx = UnityEngine.Random.Range(0, 4);
        options = new string[4];
        int firstChosen = -1;
        int secondChosen = -1;
        for (int i = 0; i < 4; i++)
        {
            if (i == correctIdx)
            {
                options[i] = correct;
                alternatives[i] = true;
            } 
            else {
                int randDinoIdx = GenerateRandomDinoIndex(dinoId, firstChosen, secondChosen);
                if (firstChosen < 0)
                {
                    firstChosen = randDinoIdx;
                } else if (secondChosen < 0) {
                    secondChosen = randDinoIdx;
                }
                options[i] = DinoManager.instance.GetDinoById(randDinoIdx).getCharacteristicByIdx(type);
                
                if (options[i] == correct)
                {
                    alternatives[i] = true;
                }
            }
        }
    }
}

public class ExerciseSet
{
    public int exercisesNumber;
    public Exercise[] exercises;

    public ExerciseSet(int number, int byHabitat, int byDietType, int byPeriod, int byHeight)
    {
        this.exercisesNumber = number;
        this.exercises = new Exercise[number];

        // Decide on counts distribution
        int differentTypes = byHabitat + byDietType + byPeriod + byHeight;
        int[] countsPerTypes = new int[differentTypes];
        int div = number / differentTypes;
        int remainder = number % differentTypes;
        if(remainder == 0) { remainder = div; }
        for (int i = 0; i < differentTypes - 1; i++)
        {
            countsPerTypes[i] = div;
        }
        countsPerTypes[differentTypes - 1] = remainder;

        // Distribute counts to the correct types
        int idx = 0;

        if (byHabitat != 0) {
            byHabitat = countsPerTypes[idx];
            idx++;
        }
        if (byDietType != 0)
        {
            byDietType = countsPerTypes[idx];
            idx++;
        }
        if (byPeriod != 0)
        {
            byPeriod = countsPerTypes[idx];
            idx++;
        }
        if (byHeight != 0)
        {
            byHeight = countsPerTypes[idx];
        }

        for (int i = 0; i < number; i++)
        {
            int dinoId = UnityEngine.Random.Range(0, 9);
            if (i < byHabitat)
            {
                this.exercises[i] = new Exercise(11, "environment", dinoId);
            }
            else if (i < byHabitat + byDietType)
            {
                this.exercises[i] = new Exercise(7, "diet type", dinoId);
            } 
            else if ( i < byHabitat + byDietType + byPeriod)
            {
                this.exercises[i] = new Exercise(4, "period", dinoId);
            }
            else
            {
                this.exercises[i] = new Exercise(9, "height", dinoId);
            }
        }
    }
}

public class ExerciseCreator : MonoBehaviour
{

    public static ExerciseCreator instance;
    public ExerciseSet exerciseSet;

    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button backButton;

    [SerializeField]
    private Toggle habitatToggle;
    [SerializeField]
    private Toggle dietToggle;
    [SerializeField]
    private Toggle periodToggle;
    [SerializeField]
    private Toggle heightToggle;


    [SerializeField]
    private TMP_InputField questionsNumberInput;
    [SerializeField]
    private TMP_InputField hintsNumberInput;

    [SerializeField]
    private GameObject warningText;
    float warningTimer = -1f;

    int numberQuestions;
    int numberHints;

    private void Awake()
    {
        instance = this;
        instance.numberQuestions = 0;
        startButton.onClick.AddListener(StartExercise);
        backButton.onClick.AddListener(GoBackToMainMenu);
    }

    private void Start()
    {
       warningText.SetActive(false);
    }

    private void StartExercise()
    {
        string input = questionsNumberInput.text;
        if (!int.TryParse(input, out instance.numberQuestions)) {
            warningText.SetActive(true);
            warningTimer = 0f;
            return;
        }
        if (instance.numberQuestions < 1 || instance.numberQuestions > 50)
        {
            warningText.SetActive(true);
            warningTimer = 0f;
            return;
        }
        int byHabitat = habitatToggle.isOn ? 1 : 0;
        int byDietType = dietToggle.isOn ? 1 : 0;
        int byPeriod = periodToggle.isOn ? 1 : 0;
        int byHeight = heightToggle.isOn ? 1 : 0;
        instance.exerciseSet = new ExerciseSet(instance.numberQuestions, byHabitat, byDietType, byPeriod, byHeight);
        Debug.Log("Exercises Created!");
        foreach (Exercise e in instance.exerciseSet.exercises)
        {
            Debug.Log(e.question);
        }
        UIManager.Instance.openPractice();
        GameEvents.current.ActivateExerciseSet();
    }

    private void GoBackToMainMenu()
    {
        UIManager.Instance.openMainMenu();
    }

    private void Update()
    {
        if (warningTimer >= 0f && warningTimer < 5f)
        {
            warningTimer += Time.deltaTime;
        } else if (warningTimer >= 5f) { 
            warningTimer = -1f; 
            warningText.SetActive(false);
        }
    }
}
