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
    public bool modification = false;
    private bool mod = false;



    void Update()
    {
        if (!modification)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!GameManager.inventory)
                {
                    weaponWheelSelected = !weaponWheelSelected;
                    if (weaponWheelSelected)
                    {
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                }
            }
        }
        else
        {
            if (mod)
            {
                weaponWheelSelected = true;
            }
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
        
        
    }

    public void CloseWheel()
    {
        weaponWheelSelected = !weaponWheelSelected;
        mod = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ModifyWheel()
    {
        mod = true;
    }
}
