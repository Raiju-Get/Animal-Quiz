using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Answers",fileName = "AnswerSO")]
[InlineEditor()]
public class AnswerSO : ScriptableObject
{
   
   [HorizontalGroup("Game Data",75)]
   [PreviewField(75), HideLabel]
   public Sprite image;



   [VerticalGroup("Game Data/Stats")]
   [LabelWidth(70)]
   public string answer;
   [VerticalGroup("Game Data/Stats")]
   [LabelWidth(70)]
   public AudioClip audioClip;
 
  
   

 

}
