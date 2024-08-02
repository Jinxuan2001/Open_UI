using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControl : MonoBehaviour
{
    public s_PlayerInventory playerInventory;
    public GameObject selectedItem;
    public S_GameManager gameManager;

    public s_InventoryController inventoryController;


    // Update is called once per frame
    void Update()
    {
        if (playerInventory.pickupQueue.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerInventory.PickupItem();
                Debug.Log("PICKED UP");
            }
        }
        if (Input.GetMouseButtonDown(0) && !inventoryController.inventoryOpened && !Input.GetKey(KeyCode.Tab) && !gameManager.gamePaused)
        {
            Debug.Log("THROW");
            s_Item curItem = selectedItem.GetComponent<s_Item>();
            if (curItem.isThrowable)
            {
                playerInventory.ThrowItem(curItem);
            }
        }
    }
}
