using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;


public class InventoryManager : MonoBehaviour
{

    public Dictionary<int, Item> invItems;

    public UnityEvent OnInvChange = new UnityEvent();
   

    public GameObject[] itemPanel;
    public GameObject InvGUI;
    public GameObject Crosshair;

    bool EnableInventory = false;

    private void Start()
    {
        invItems = new Dictionary<int, Item>();
        OnInvChange = new UnityEvent();


       
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            EnableInventory = !EnableInventory;
        }

        InvGUI.SetActive(EnableInventory);
        Crosshair.SetActive(!EnableInventory);

    }



    //item -> dictionary
    //When called, takes the index and name of item, and adds it to dictionary

    public void AddItem(Item item)
    {
        int index = GetIndexValue();

        if(index != -1)
        {
            invItems.Add(index, item);

            switch (item.GetItemTag())
            {
                case "Key":

                    Sprite newSprite = Resources.Load<Sprite>("Sprites/key") as Sprite;

                    if (!newSprite) { Debug.Log("sprite has not been loaded in!"); }

                    itemPanel[index].transform.Find("ItemImage").GetComponent<Image>().overrideSprite = newSprite;
                    break;
            }

            Debug.Log("Item added: " + item.GetItemName());
        }
        
    }
    

    //Find free space in inventory
    public int GetIndexValue()
    {
        for(int i = 0; i <= invItems.Count; i++)
        {
            if (!invItems.ContainsKey(i))
            {
                return i;
            }
        }

        return -1;

    }

    public void RemoveItem(int index)
    {
        invItems.Remove(index);
        itemPanel[index].transform.Find("ItemImage").GetComponent<Image>().overrideSprite = null;
    }

    //possible to do: add more inventory function? 

}
