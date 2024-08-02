using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Item : MonoBehaviour
{
    public s_obj_ItemInfo itemInfo;

    public string name;
    public string description;
    public Sprite icon;
    public GameObject model;
    public bool isThrowable;
    public bool isObject;


    void Start()
    {
        if (itemInfo != null)
        {
            this.name = itemInfo.itemName;
            this.description = itemInfo.description;
            this.icon = itemInfo.itemIcon;
            this.model = itemInfo.model;
            this.isThrowable = itemInfo.isThrowable;
        }
        else
        {
            Debug.Log("MISSING ITEM INFO!!!");
        }
    }

    public void LightOn()
    {
        if (isObject)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void LightOff()
    {
        if (isObject)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
