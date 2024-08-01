using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class s_Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public string name;
    public string description;
    public Sprite icon;
    public Image dragIcon;
    public Image infoImage;

    [HideInInspector] public Transform parentAfterDrag;


    //Item Info
    public GameObject menu;
    public GameObject infoPanel;
    public TextMeshProUGUI itemInfoName;
    public TextMeshProUGUI itemInfoDescription;

    void Start()
    {
        //menu.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin dragging");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        dragIcon.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        //menu.SetActive(false);
        //infoPanel.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End dragging");
        transform.SetParent(parentAfterDrag);
        dragIcon.raycastTarget = true;
    }

    //To Be Replaced
    public void OpenMenu()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    infoPanel.SetActive(false);
        //    GameManager.modSlected = icon;
        //    GameManager.modName = name;
        //    menu.transform.position = gameObject.transform.position;
        //    menu.SetActive(true);
        //    UpdateInfo();
        //    Debug.Log(GameManager.modSlected);
        //}
    }

    public void UpdateInfo()
    {
        Debug.Log("Updating Item Info");

        infoImage.sprite = icon;
        itemInfoName.text = name;
        itemInfoDescription.text = description;
        /*
        if (type == "firearm")
        {
            //tmp2.text = "Firepower: " + dmg.ToString() + "  Fire Rate: " + rate.ToString() + "  Bullet Caliber: " + bullet;
        }
        else
        {
            tmp2.text = "";
        }
        */
        //tmp3.text = description;
    }
}
