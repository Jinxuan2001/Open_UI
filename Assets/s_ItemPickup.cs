using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<s_PlayerInventory>().AddPickupQueue(this.GetComponent<s_Item>());
            //player.GetComponent<s_PlayerInventory>().OpenPickupPrompt(this.GetComponent<s_Item>().name);
            Debug.Log("CLOSE TO ITEM");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<s_PlayerInventory>().RemoveItemQueue(this.GetComponent<s_Item>());
            //player.GetComponent<s_PlayerInventory>().ClosePickupPrompt();
            Debug.Log("LEFT ITEM");
        }
    }

    //public void PickedUp()
    //{
    //    Destroy(gameObject);
    //}
}
