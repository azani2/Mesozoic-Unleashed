using System;

[Serializable]
public class DialogueLine
{
    public string speaker;      
    public string text;         
    public string spriteName;   
}

[Serializable]
public class DialogueData
{
    public DialogueLine[] lines;
}
