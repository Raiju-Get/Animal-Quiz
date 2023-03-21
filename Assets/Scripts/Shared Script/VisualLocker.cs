using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VisualLocker : MonoBehaviour
{
    [SerializeField] RegistryScript registryScript;
    [SerializeField] GameObject isLockedUI;
    [SerializeField] List<GameObject> uiButtons = new List<GameObject>();
    [SerializeField] EventSystem eventSystem;



    private void Start()
    {

        if (!SaveSystem.LoadData())
        {
            isLockedUI.SetActive(false);
            for (int i = 0; i < uiButtons.Count; i++)
            {
                uiButtons[i].SetActive(true);
            }
            eventSystem.enabled= true;
        }
        else
        {
            isLockedUI.SetActive(true);
            for (int i = 0; i < uiButtons.Count; i++)
            {
                uiButtons[i].SetActive(false);
            }
            eventSystem.enabled = false;
        }

    }
}
