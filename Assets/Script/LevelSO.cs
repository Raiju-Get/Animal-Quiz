using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Object",fileName = "Level")]
public class LevelSO : ScriptableObject
{
   public List<QuestionSO> questionArray = new List<QuestionSO>();
}
