using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{

 
    public Dialouge dialouge;
    public GameObject dialougeBox;
    public PlayerController playerController;

    public void TriggerDialouge()
    {
        playerController.allowRaycast = false;
        dialougeBox.SetActive(true);
        FindObjectOfType<DialogueManager>().allowButtonPress = true;
        FindObjectOfType<DialogueManager>().StartDialouge(dialouge);
    }
}
