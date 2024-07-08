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
            if (!GameManager.inventory)
            {
                weaponWheelSelected = !weaponWheelSelected;
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
    }
}
