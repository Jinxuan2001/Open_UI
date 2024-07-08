using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject inventory;
    public bool inventoryOpend = false;

    private void Start()
    {
        inventory.SetActive(inventoryOpend);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.inventory = !GameManager.inventory;
            inventoryOpend = !inventoryOpend;
        }

        inventory.SetActive(inventoryOpend);
    }
}
