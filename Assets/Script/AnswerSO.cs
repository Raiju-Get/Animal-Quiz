using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Answers",fileName = "AnswerSO")]
public class AnswerSO : ScriptableObject
{
   public string answer;
   public Sprite image;
   public AudioClip audioClip;

}
