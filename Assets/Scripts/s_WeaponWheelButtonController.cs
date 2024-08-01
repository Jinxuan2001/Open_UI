using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class s_WeaponWheelButtonController : MonoBehaviour
{

    //public int id;
    private Animator anim;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public bool hasItem = false;

    [Header("Item Info")]
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public Sprite emptyIcon;

    public bool modifiaction = false;
    public GameObject wpMod = null;
    public GameObject wpWheel = null;
    public GameObject wheelButton = null;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (hasItem)
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = icon;
        }
        else
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = emptyIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (modifiaction)
        {
            if (selected)
            {
                wpMod.GetComponent<Image>().sprite = GameManager.modSlected;
                wpWheel.GetComponent<Image>().sprite = GameManager.modSlected;
                wheelButton.GetComponent<s_WeaponWheelButtonController>().itemName = GameManager.modName;
                wheelButton.GetComponent<s_WeaponWheelButtonController>().icon = GameManager.modSlected; 
            }
        }
        else
        {
            if (selected)
            {
                selectedItem.sprite = icon;
                itemText.text = itemName;
            }
        }
    }

    public void Selected()
    {
        selected = true;
        //s_WeaponWheelController.weaponID = id;
    }

    public void Deselected()
    {
        selected = false;
        //s_WeaponWheelController.weaponID = 0;
    }

    public void HoverEnter()
    {
        anim.SetBool("Hover", true);
        itemText.text = itemName;
    }

    public void HoverExit()
    {
        anim.SetBool("Hover", false);
        itemText.text = "";
    }
}
