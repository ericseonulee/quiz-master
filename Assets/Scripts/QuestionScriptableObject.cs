using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question")]
public class QuestionScriptableObject : ScriptableObject {
    [SerializeField] [TextArea(2,6)] private string question = "Enter new question test here.";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;

    public string GetQuestion() {
        return question;
    }

    public int GetCorrectAnswerIndex() {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index) {
        return answers[index];
    }
}