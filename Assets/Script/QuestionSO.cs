using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question",fileName = "QuestionSO")]
public class QuestionSO : ScriptableObject
{
    public string question;

    public AnswerSO[] answerArray = new AnswerSO[4];
    [Range(0,3)]
    public int correctIndex;
}
