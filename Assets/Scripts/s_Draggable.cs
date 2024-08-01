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
        infoPanel = GameObject.FindWithTag("InfoPanel");
        if (infoPanel != null)
        {
            itemInfoName = infoPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            itemInfoDescription = infoPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            infoImage = infoPanel.transform.GetChild(2).GetComponent<Image>();
        }
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
        this.gameObject.GetComponent<Image>().rectTransform.localScale = new Vector3(0.1f, 0.1f, 1f);

        //menu.SetActive(false);
        //infoPanel.SetActive(false);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End dragging");
        transform.SetParent(parentAfterDrag);
        this.gameObject.GetComponent<Image>().rectTransform.localScale = new Vector3(1.0f, 1.0f, 1f);
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
        if (infoPanel != null)
        {
            infoImage.sprite = icon;
            itemInfoName.text = name;
            itemInfoDescription.text = description;
        }
    }
}
