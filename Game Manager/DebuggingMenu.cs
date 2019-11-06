/*
    Important player positions:
      
    - Level 1: (-40.45, 12.5, 25)
    - debug room: -181, 10.9, -78.17

 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DebuggingMenu : MonoBehaviour
{

    public GameObject Player;
    public GameObject Camera;
    public GameObject DebugMenuUI;

    


    public bool enableDebugger = false;

    
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            DebugMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
           
            if(!Player)
            {
                Debug.Log("Player was not found");
            }

        }

       
    }

    public void PlayerLocations(int locationInt)
    {

        if(locationInt < 1)
        {
            Player.GetComponent<CharacterController>().enabled = false;
            Player.GetComponent<PlayerController>().enabled = false;
            Camera.GetComponent<MouseLook>().enabled = true;
            Camera.GetComponent<MouseLook>().allowXClamp = true;
        } else {
            Player.GetComponent<CharacterController>().enabled = true;
            Player.GetComponent<PlayerController>().enabled = true;
            Camera.GetComponent<MouseLook>().enabled = true;
            Camera.GetComponent<MouseLook>().allowXClamp = false;
        }
      
            


        switch (locationInt)
        {
            case 0:
                Player.transform.position = new Vector3(-4.2f,3.72f, -188);

                break;


            case 1:
                Player.transform.position = new Vector3(-40.45f, 12.5f, -34);
               
                break;

            case 4:
                Player.transform.position = new Vector3(-181, 10.9f, -78.17f);

                break;

            default:
                Debug.Log("No such area!");
                break;

        }



    }

    
}
