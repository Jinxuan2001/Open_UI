using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayWeaponInfo : MonoBehaviour, IDragHandler
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OpenPanel()
    {
        gameObject.SetActive (true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
    }
}
