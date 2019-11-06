using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class InventoryManager : MonoBehaviour
{

    public Dictionary<int, Item> invItems;
    public GameObject itemSlot;
    


    private void Start()
    {
        invItems = new Dictionary<int, Item>();
    }

    //item -> dictionary
    //When called, takes the index and name of item, and adds it to dictionary
    public void AddItem(Item item)
    {

        int index = GetIndexValue();

        invItems.Add(index, item);
        Debug.Log("Items: " + invItems.Count);
        
    }
    

    //Find free space in inventory
    public int GetIndexValue()
    {
        for(int i = 0; i < invItems.Count; i++)
        {
            if (!invItems.ContainsKey(i))
            {
                return i;
            }
        }

        return -1;

    }
}
