using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int scoreIncrement;
    [SerializeField] List<TextMeshProUGUI> scoretexts = new List<TextMeshProUGUI>();


    private void Start()
    {
        GetScoreText();
    }
    public void AddScore()
    {
        score += scoreIncrement;
        GetScoreText();
    }

    private void GetScoreText()
    {
        for (int i = 0; i < scoretexts.Count; i++)
        {
            scoretexts[i].text = score.ToString();
        }
    }

    public int GetScore()
    { return score; }
}
