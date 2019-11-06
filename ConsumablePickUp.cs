using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablePickUp : Interactable
{

    public InventoryManager Inventory;
    public int ITEM_AMOUNT;

    public override void Interact()
    {
        base.Interact();

        PickUp();
     
    }

    void PickUp()
    {
        Item item = new Item(gameObject.name, ITEM_AMOUNT);

        Inventory.AddItem(item);
        gameObject.SetActive(false);
    }
}
