using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{

    string name;
    string itemType;
    int itemAmount;
    string itemTag;

    //assign image to this, so when added to inv you'd assign everything just to the transform

    public string GetItemName()
    {
        return name;
    }

    public int GetItemAmount()
    {
       return itemAmount;
    }

    public string GetItemTag()
    {
        return itemTag;
    }


    public Item()
    {
        name = "item";
        itemAmount = 1;
    }

    public Item(string n, string t,int amount)
    {
        name = n;
        itemTag = t;
        itemAmount = amount;
    }

}
