using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerControl : MonoBehaviour
{
    public s_PlayerInventory playerInventory;
    public GameObject selectedItem;

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
            if (Input.GetMouseButtonDown(0))
            {
                //playerInventory.ThrowItem();
            }
        }
    }
}