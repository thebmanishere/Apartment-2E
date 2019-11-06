using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : Interactable
{

    public bool[] key;
    public bool isDoorLocked;

    public override void Interact()
    {
        base.Interact();

        //can use a different method for special items vs normal items

        Unlock();
    }

   void Unlock()
   {
       
   }
}
