using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Item : MonoBehaviour
{
    public s_obj_ItemInfo itemInfo;

    public string name;
    public string description;
    public Sprite icon;
    public bool isThrowable;


    void Start()
    {
        if (itemInfo != null)
        {
            this.name = itemInfo.itemName;
            this.description = itemInfo.description;
            this.icon = itemInfo.itemIcon;
            this.isThrowable = itemInfo.isThrowable;
        }
        else
        {
            Debug.Log("MISSING ITEM INFO!!!");
        }
    }
}
