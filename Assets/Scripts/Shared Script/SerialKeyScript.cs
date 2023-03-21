using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SerialKeyScript : MonoBehaviour
{

    [SerializeField] RegistryScript registryScript;
    [SerializeField] GameObject UIBlocker;



    public void AcivateKey()
    {
        if (registryScript.isLocked)
        {
            SaveSystem.SaveData(true);
            registryScript.AddMinutesData();
            UIBlocker.SetActive(false);
        }
       
       
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AcivateKey();
        }
    }
}
