using UnityEngine;

public class ItemPickUp : Interactable
{
    public override void Interact()
    {
        base.Interact();

        //can use a different method for special items vs normal items

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up item...");

        GameObject itemPos = GameObject.FindGameObjectWithTag("ItemPos");
        
        transform.position = itemPos.transform.position;
        transform.rotation = itemPos.transform.rotation;

        transform.parent = Camera.main.transform;

        switch(gameObject.name)
        {
            case "Lighter":
                GetComponent<FlashlightFunctions>().playerHasLighter = true;
                break;
        }
    }
}
