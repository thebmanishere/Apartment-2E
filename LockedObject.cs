using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedObject : Interactable
{
    
    public string[] ITEM_NAME;
    public InventoryManager Inv;

    public override void Interact()
    {
        base.Interact();

        UnlockState();

    }

    bool UnlockState()
    {

        //if true, unlock object

        if (checkForKeys())
        {
            Debug.Log(gameObject.name + " has been unlocked.");

            return true;

        }

        Debug.Log(gameObject.name + " is locked.");
        return false;
    }

    bool checkForKeys()
    {

        bool[] hasKey = new bool[ITEM_NAME.Length];
       
        for (int h = 0; h < hasKey.Length - 1; h++)
        {
            hasKey[h] = true;
        }

        if (ITEM_NAME.Length >= 1)
        {
          
            for (int i = 0; i < ITEM_NAME.Length - 1; i++)
            {               
                string name = Inv.SearchForItem(ITEM_NAME[i]);

                if (name != ITEM_NAME[i])
                {
                    hasKey[i] = false;
                    Debug.Log(ITEM_NAME[i] + " has not been found in inventory.");
                }               
            }
        }

        else if(ITEM_NAME.Length < 1)
        {
            if (name != ITEM_NAME[0])
            {
                hasKey[0] = false;
            }
        }

        for (int j = 0; j < hasKey.Length - 1; j++)
        {
            if (!hasKey[j]) return false;
        }


        return true;
       
    }






}
