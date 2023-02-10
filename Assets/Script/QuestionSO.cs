using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Question",fileName = "QuestionSO")]
public class QuestionSO : ScriptableObject
{
  

    [BoxGroup("Current Image"),HideLabel,PreviewField(75)]
    public AnswerSO[] answerArray = new AnswerSO[4];
    
    [BoxGroup("Question Field")]
    public string question;
    [BoxGroup("Question Field")]
    [Range(0,3)]
    public int correctIndex;
}
