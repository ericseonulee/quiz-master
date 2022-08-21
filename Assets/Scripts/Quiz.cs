using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionScriptableObject[] questionSOs;
    [SerializeField] private GameObject[] answerButtons;
    private int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] int currentQuestion = 0;

    void Start()
    {
        DisplayQuestion();
    }

    public void DisplayQuestion() {
        questionText.text = questionSOs[currentQuestion].GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++) {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionSOs[currentQuestion].GetAnswer(i);
        }

        SetButtonState(true);
    }

    void GetnextQuestion() {
        currentQuestion++;
        if (currentQuestion <= answerButtons.Length) {
            DisplayQuestion();
        }
    }

    public void OnAnswerSelected(int index) {
        Image selectedButtonImage = answerButtons[index].GetComponent<Image>();

        if (index == questionSOs[currentQuestion].GetCorrectAnswerIndex()) {

            questionText.text = "Correct!";
            selectedButtonImage.sprite = correctAnswerSprite;
            
        }
        else {
            Image correctButtonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            string correctAnswer = questionSOs[currentQuestion].GetAnswer(correctAnswerIndex);

            questionText.text = "Incorrect! Correct answer is:\n" + correctAnswer;
            correctButtonImage.sprite = correctAnswerSprite; 
            selectedButtonImage.color = new Color32(150, 255, 166, 255);
        }

        SetButtonState(false);

        Invoke("GetnextQuestion", 3);
    }

    void SetButtonState(bool state) {
        for (int i = 0; i < answerButtons.Length; i++) {
            Button button = answerButtons[i].GetComponent<Button>();

            button.interactable = state;
            
            if (state) {
                ResetButton(i);
            }
        }
    }

    void ResetButton(int index) {
        Button button = answerButtons[index].GetComponent<Button>();
        Image buttonImage = button.GetComponent<Image>();
        buttonImage.color = new Color32(255, 255, 255, 255);
        buttonImage.sprite = defaultAnswerSprite;
    }
}
