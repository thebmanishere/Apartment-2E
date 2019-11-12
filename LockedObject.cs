using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedObject : Interactable
{
    public bool KEY_AMOUNT;
    public string KEY_NAME;

    public override void Interact()
    {
        base.Interact();

        UnlockState();

    }

    bool UnlockState()
    {

        //if true, unlock object

        if(checkForKeys())
        {
            return true;
        }

        Debug.Log("Player has clicked on " + gameObject.name);

        return false;
    }

    bool checkForKeys()
    {
        //check inventory for items
        //to do: figure out how inventory and this can communicate without direct reference 

        return false;
    }






}
