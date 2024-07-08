using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string name;
    public string type;

    public int dmg = 0;
    public int rate = 0;
    public string bullet = "";

    public string info;

    public GameObject menu;
    public GameObject infoPanel;

    public Image infoImage;
    public Sprite sp;
    public TextMeshProUGUI tmp1;
    public TextMeshProUGUI tmp2;
    public TextMeshProUGUI tmp3;

    public Image image;
    [HideInInspector] public Transform parentAfterDrag;

    void Start()
    {
        menu.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin dragging");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        menu.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End dragging");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void OpenMenu()
    {
        if (Input.GetMouseButtonDown(1))
        {
            infoPanel.SetActive(false);

            menu.transform.position = gameObject.transform.position;
            menu.SetActive(true);
            UpdateInfo();
        }
    }

    public void UpdateInfo()
    {
        tmp1.text = name;
        infoImage.sprite = sp;
        if(type == "firearm")
        {
            tmp2.text = "Firepower: " + dmg.ToString() + "  Fire Rate: " + rate.ToString() + "  Bullet Caliber: " + bullet;
        }
        else
        {
            tmp2.text = "";
        }
        tmp3.text = info;
    }
}
