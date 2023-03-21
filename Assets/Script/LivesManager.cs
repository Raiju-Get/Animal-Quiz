using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public int maxLives =3;
    public int currenntLives;
    [SerializeField] Image[] livesImage = new Image[3];


    private void Awake()
    {
        currenntLives = maxLives;
        for (int i = 0; i < livesImage.Length; i++)
        {
            livesImage[i].gameObject.SetActive(true);
        }
    }
    
    
    public void TakeLives()
    {
        currenntLives--;
        Checklives();
    }

    public void Checklives()
    {
        livesImage[currenntLives].gameObject.SetActive(false);
    }

   
}
