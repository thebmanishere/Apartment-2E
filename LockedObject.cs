using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedObject : Interactable
{
    
    public string[] ITEM_NAME;
    //public GameObject Inventory;
    public InventoryManager Inv;

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
            Debug.Log(gameObject.name + " has been unlocked.");

            return true;

        }

        Debug.Log(gameObject.name + " is locked.");
        return false;
    }

    bool checkForKeys()
    {

        //doesn't work with more than one key

        if (ITEM_NAME.Length >= 1)
        {
            bool[] hasKey = new bool[ITEM_NAME.Length];



            //set them all to true, and then if item isn't 
            //found, set it to false

            for (int h = 0; h < hasKey.Length; h++)
            {
                hasKey[h] = true;
            }
            

            for (int i = 0; i <= ITEM_NAME.Length; i++)
            {                
                //check for each string
                //running into array out of bounds error 

                if (!Inv.SearchForItem(ITEM_NAME[i]))
                {
                    hasKey[i] = false;
                }
            }

            for (int j = 0; j < hasKey.Length; j++)
            {
                if (hasKey[j] == true) return true;             
            }
        }
       
            //else if (Inv.SearchForItem(ITEM_NAME[0]))
            //{
            //    return true;
            //}


        return false;
    }






}
