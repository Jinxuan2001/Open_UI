using UnityEngine;
using UnityEngine.UI;

public class s_WeaponWheelController : MonoBehaviour
{
    public Animator anim;
    public Animator animBckground;
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelSelected = !weaponWheelSelected;
        }

        if (weaponWheelSelected)
        {
            anim.SetBool("OpenWeaponWheel", true);
            animBckground.SetBool("OpenWeaponWheel", true);
        }
        else
        {
            anim.SetBool("OpenWeaponWheel", false);
            animBckground.SetBool("OpenWeaponWheel", false);
        }

        switch (weaponID)
        {
            case 0: //nothing selected
                selectedItem.sprite = noImage;  
                break;
            case 1:
                Debug.Log("Pistol");
                selectedItem.sprite = noImage;
                break;
            case 2:
                Debug.Log("Melee");
                selectedItem.sprite = noImage;
                break;
            case 3:
                Debug.Log("Assault Rifle");
                selectedItem.sprite = noImage;
                break;
            case 4:
                Debug.Log("Sniper");
                selectedItem.sprite = noImage;
                break;
            case 5:
                Debug.Log("SMG");
                selectedItem.sprite = noImage;
                break;
            case 6:
                Debug.Log("LMG");
                selectedItem.sprite = noImage;
                break;
            case 7:
                Debug.Log("Launcher");
                selectedItem.sprite = noImage;
                break;
            case 8:
                Debug.Log("Special");
                selectedItem.sprite = noImage;
                break;
        }
    }
}
