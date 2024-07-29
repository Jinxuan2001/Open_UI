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
    public s_PlayerMovement playerMovement;



    void Update()
    {
        if (!modification)
        {
            if (!GameManager.inventory)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    weaponWheelSelected = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0.1f;
                    playerMovement.EnterMenu();
                }
                if (Input.GetKeyUp(KeyCode.Tab))
                {
                    weaponWheelSelected = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Time.timeScale = 1.0f;
                    playerMovement.ExitMenu();
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
        //weaponWheelSelected = !weaponWheelSelected;
        mod = false;
    }

    public void ModifyWheel()
    {
        mod = true;
    }
}
