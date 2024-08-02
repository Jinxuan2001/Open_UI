using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            s_Draggable draggedItem = dropped.GetComponent<s_Draggable>();
            draggedItem.parentAfterDrag = transform;
        }
        //if (this.GetComponent<s_WeaponWheelButtonController>() != null)
        //{
        //    if (!this.GetComponent<s_WeaponWheelButtonController>().hasItem)
        //    {
        //        GameObject dropped = eventData.pointerDrag;
        //        if (dropped.CompareTag("Finish"))
        //        {
        //            Destroy(dropped);
        //        }
        //    }
        //}
    }

}
