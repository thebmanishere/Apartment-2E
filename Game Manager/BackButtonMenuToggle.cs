using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonMenuToggle : MonoBehaviour
{
    //public Button ;
    public MainMenu IsMainMenuDisabled;
    public GameObject[] BackButtons;


    //private void Start()
    //{      
    //    BackButton.onClick.AddListener(ToggleMenu);
    //}

    private void Update()
    {
        ToggleMenu();
    }

    private void ToggleMenu()
    {
  
        if (IsMainMenuDisabled.DisableMainMenuUI)
        {
            BackButtons[0].SetActive(false);
            BackButtons[1].SetActive(true);
        }

    }
}
