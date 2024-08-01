using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class s_PlayerInventory : MonoBehaviour
{
    //All items in the player's inventory
    public List<Tuple<s_Item, int>> playerItems;
    public Queue<s_Item> pickupQueue = new Queue<s_Item>();

    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public GameObject pickupPrompt;
    public GameObject itemInfoPanel;
    public TextMeshProUGUI itemInfoName;
    public TextMeshProUGUI itemInfoDescription;
    public Image itemInfoImage;
    

    void Start()
    {
        pickupPrompt.SetActive(false);
        playerItems = new List<Tuple<s_Item, int>>();
    }

    public void PickupItem()
    {
        s_Item curItem = RemovePickupQueue();
        AddItem(curItem);
        ClosePickupPrompt();
    }

    public void ThrowItem(s_Item item_)
    {

    }


    public void AddPickupQueue(s_Item item_)
    {
        pickupQueue.Enqueue(item_);
        OpenPickupPrompt(pickupQueue.Peek().name);
    }

    public s_Item RemovePickupQueue()
    {
        s_Item curItem = pickupQueue.Dequeue();
        if (pickupQueue.Count > 0)
        {
            OpenPickupPrompt(pickupQueue.Peek().name);
        }
        else
        {
            ClosePickupPrompt();
        }
        return curItem;
    }

    public void RemoveItemQueue(s_Item item_)
    {
        Queue<s_Item> tempQueue = new Queue<s_Item>();

        while (pickupQueue.Count > 0)
        {
            s_Item tempItem = pickupQueue.Dequeue();

            if (tempItem != item_)
            {
                tempQueue.Enqueue(tempItem);
            }
        }

        while (tempQueue.Count > 0)
        {
            pickupQueue.Enqueue(tempQueue.Dequeue());
        }

        if (pickupQueue.Count > 0)
        {
            OpenPickupPrompt(pickupQueue.Peek().name);
        }
        else
        {
            ClosePickupPrompt();
        }
    }

    public void AddItem(s_Item item_)
    {
        //Checks if Item is already in inventory
        Tuple<s_Item, int> foundItem = playerItems.Find(item => item.Item1.name == item_.name);

        if (foundItem != null)
        {
            int quantity = foundItem.Item2 + 1;
            int index = playerItems.IndexOf(foundItem);

            //Updates Inventory and Increments Quantity
            playerItems[index] = new Tuple<s_Item, int>(foundItem.Item1, quantity);
        }
        else
        {
            // If Item isn't in inventory (Invetory Slot Instatiation)
            playerItems.Add(new Tuple<s_Item, int>(item_, 1));
            AddSlot(item_);
        }
    }

    public bool RemoveItem(s_Item item_)
    {
        //Checks if Item is already in inventory
        Tuple<s_Item, int> foundItem = playerItems.Find(item => item.Item1.name == item_.name);

        if (foundItem != null)
        {
            int quantity = foundItem.Item2 - 1;
            int index = playerItems.IndexOf(foundItem);

            //Updates Inventory and Decrements Quantity
            if (quantity <= 0)
            {
                playerItems.Remove(foundItem);
                return true;
            }
            else
            {
                playerItems[index] = new Tuple<s_Item, int>(foundItem.Item1, quantity);
                return true;
            }
        }

        return false;
    }

    public int ItemQuantity(s_Item item_)
    {
        //Checks Item Quantity
        Tuple<s_Item, int> foundItem = playerItems.Find(item => item.Item1.name == item_.name);

        if (foundItem != null)
        {
            return foundItem.Item2;
        }

        return -1;
    }

    public void AddSlot(s_Item item_)
    {
        //Find Empty Slot in Inventory -> Instantiate the Slot Prefab as a child of that -> replace information with Item Info
        //iterating through each possible slot of inventory
        foreach (Transform child in inventoryPanel.transform)
        {
            GameObject slotPanel = child.gameObject;
            if (slotPanel.transform.childCount == 0)
            {
                GameObject curSlot = Instantiate(slotPrefab);
                curSlot.transform.SetParent(slotPanel.transform, false);
                curSlot.GetComponent<s_Draggable>().name = item_.name;
                curSlot.GetComponent<s_Draggable>().description = item_.description;
                curSlot.GetComponent<s_Draggable>().icon = item_.icon;
                curSlot.GetComponent<Image>().sprite = item_.icon;
                curSlot.GetComponent<s_Draggable>().dragIcon = curSlot.GetComponent<Image>();
                curSlot.GetComponent<s_Draggable>().infoImage = curSlot.GetComponent<Image>();

                curSlot.GetComponent<s_Draggable>().infoPanel = itemInfoPanel;
                curSlot.GetComponent<s_Draggable>().itemInfoName = this.itemInfoName;
                curSlot.GetComponent<s_Draggable>().itemInfoDescription = this.itemInfoDescription;
                curSlot.GetComponent<s_Draggable>().infoImage = this.itemInfoImage;
                Destroy(item_.gameObject);
                break;
            }
        }
    }

    public void OpenPickupPrompt(string name_)
    {
        pickupPrompt.transform.GetChild(2).GetComponent<TMP_Text>().text = name_;
        pickupPrompt.SetActive(true);
    }

    public void ClosePickupPrompt()
    {
        pickupPrompt.SetActive(false);
    }

}
