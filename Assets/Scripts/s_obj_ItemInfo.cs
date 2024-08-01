using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class s_obj_ItemInfo : ScriptableObject
{
    public new string itemName;
    public string description;

    public Sprite itemIcon;
    public bool isThrowable;
}
