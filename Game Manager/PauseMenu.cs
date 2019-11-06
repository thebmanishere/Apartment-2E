using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public MouseLook mouseLook;
    public MainMenu canPause;
    public GameObject[] PauseMenuObj;
    public Image MenuBG;

    [HideInInspector]
    public bool enable;

    private void Update()
    {
       
        
        if (canPause.AllowPauseMenu)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                enable = !enable;  

               
                MenuBG.CrossFadeAlpha(1f, .3f, false);

                PauseMenuObj[0].SetActive(enable);
                PauseMenuObj[1].SetActive(enable);
                mouseLook.CursorState(false);
                mouseLook.enabled = false;
                
                if(!enable)
                {
                    mouseLook.CursorState(true);

                    enable = false;
                    mouseLook.enabled = true;
                    mouseLook.CursorState(true);

                    PauseMenuObj[0].SetActive(enable);
                    PauseMenuObj[1].SetActive(enable);

                    MenuBG.CrossFadeAlpha(.001f, .3f, false);
                }

            }

        }
    }

    public void DisablePauseMenu()
    {
        enable = false;
        mouseLook.enabled = true;
        mouseLook.CursorState(true);

        PauseMenuObj[0].SetActive(enable);
        PauseMenuObj[1].SetActive(enable);

        MenuBG.CrossFadeAlpha(.001f, .3f, false);
    }
}
