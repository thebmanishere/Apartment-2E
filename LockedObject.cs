using UnityEngine;

/**
 
     Possible Issues to look out for: 

    
    - issues might arise if keys arent the first in the index of inv dictionary (when trying to remove items)
     
     
     
     
     
     */

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

        if (checkForKeys())
        {
            Debug.Log(gameObject.name + " has been unlocked.");

            for (int i = 0; i < ITEM_NAME.Length; i++)
            {
                //int index = Inv.FindItem(ITEM_NAME[i]);

                int index = Inv.FindItemIndex(ITEM_NAME[i]);

                Inv.RemoveItem(index);

            }

            GetComponent<UnlockObject>().UnlockObj();

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
                string name = Inv.FindItemName(ITEM_NAME[i]);

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
