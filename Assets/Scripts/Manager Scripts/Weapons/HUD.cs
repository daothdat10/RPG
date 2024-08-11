using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;

        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        int index = -1;

        foreach(Transform slot in inventoryPanel)
        {
            index++;
            //Border Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            //We found the empty slot
            if (index == e.Item.Slot.Id)
            {

                image.enabled=true;
                image.sprite = e.Item.Image;

                int itemCount = e.Item.Slot.Count;
                

                itemDragHandler.Item = e.Item;



                break;
            }

        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");

        int index = -1;
        foreach (Transform slot in inventoryPanel)
        {
            index++;
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if(itemDragHandler.Item == null)
            {
                continue;
            }
            if(e.Item.Slot.Id == index)
            {
                int itemCount = e.Item.Slot.Count;
                itemDragHandler.Item = e.Item.Slot.FirstItem;
                if (itemCount == 0)
                {
                    image.enabled = false;

                    image.sprite = null;
                }
                break;
            }

           
        }
    }

   
}
