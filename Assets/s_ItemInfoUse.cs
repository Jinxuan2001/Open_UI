using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_ItemInfoUse : MonoBehaviour
{
    public s_obj_ItemInfo itemInfo;

    [SerializeField]
    private string name;
    private string description;
    private Sprite icon;
    private bool isThrowable;


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
