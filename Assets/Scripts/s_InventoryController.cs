using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_InventoryController : MonoBehaviour
{
    public GameObject inventory;
    public bool inventoryOpened = false;
    public s_PlayerMovement playerMovement;

    private void Start()
    {
        inventory.SetActive(inventoryOpened);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.inventory = !GameManager.inventory;
            inventoryOpened = !inventoryOpened;
            if (inventoryOpened)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                playerMovement.EnterMenu();
                if (!playerMovement.falling)
                {
                    playerMovement.idle = true;
                    playerMovement.walking = false;
                    playerMovement.sprinting = false;
                    playerMovement.IdleAnim();
                }
            }
            else 
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerMovement.ExitMenu();
            }
        }

        inventory.SetActive(inventoryOpened);
    }
}
