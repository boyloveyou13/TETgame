using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Questions : ScriptableObject
{
    [System.Serializable]
    public class QuestionData
    {
        public string question = string.Empty;
        public string answer = string.Empty;
        public bool isTrue = false;
    }

    public QuestionData[] questionsList;
}
