using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item 
{

    private string name;
    public string itemType;
    public int itemAmount;

    public string Name
    {
        get { return Name; }

        set { name = value; }
    }

    public int ItemAmount
    {
        get { return ItemAmount; }

        set { ItemAmount = value; }


    }

    public Item()
    {
        name = "item";
        itemAmount = 1;
    }

    public Item(string n, int amount)
    {
        name = n;
        itemAmount = amount;
    }

}
