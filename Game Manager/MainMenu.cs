using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text[] MainMenuElements;
    public Button[] MainMenuButtons;
    public Image MenuBG;
    public GameObject MainCamera;
    public bool DisableMainMenuUI = false;
    public bool AllowPauseMenu = false;
   
    public void PlayGame()
    {
        Debug.Log("start the video game!");

        DisableMainMenuUI = true;
        AllowPauseMenu = true;

        MenuBG.CrossFadeAlpha(.001f, .5f, false);


        for (int i = 0; i < MainMenuElements.Length; i++)
        {
             MainMenuElements[i].CrossFadeAlpha(.001f , .5f, false);
        }

        for (int i = 0; i < MainMenuButtons.Length; i++)
        {
            MainMenuButtons[i].GetComponent<Image>().enabled = false;
            MainMenuButtons[i].interactable = false;
        }

        StartCoroutine(AllowCameraMovement());
    }

    IEnumerator AllowCameraMovement()
    {
        yield return new WaitForSeconds(1f);
        MainCamera.GetComponent<MouseLook>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().allowRaycast = true;

    }

    public void QuitGame()
    {
        Debug.Log("quit this video game!");
        Application.Quit();
        
    }

}
