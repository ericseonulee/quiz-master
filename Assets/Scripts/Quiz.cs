using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quesitonText;
    [SerializeField] private QuestionScriptableObject questionSO;

    void Start()
    {
        quesitonText.text = questionSO.GetQuestion();
    }
}
