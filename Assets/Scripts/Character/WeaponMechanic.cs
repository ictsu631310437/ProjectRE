using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMechanic : MonoBehaviour
{
    public static bool isAiming = false;
    public GameObject thePlayer;
    public float horizontalMove;
    public AudioSource pistolShot;
    public bool isFiring = false;

    public float fireRate = 0.25f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            thePlayer.GetComponent<Animator>().Play("Aiming 1Pistol");
            thePlayer.GetComponent<AutoAim>().enabled = true;
            AutoAim.aimingGun = true;

        }
        if (Input.GetMouseButtonUp(1))
        {
                isAiming = false;
                AutoAim.aimingGun = false;
                thePlayer.GetComponent<AutoAim>().enabled = false;
        }
        if (isAiming == true)
        {
            if (Input.GetButton("Horizontal"))
            {
                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                thePlayer.transform.Rotate(0, horizontalMove, 0);
            }

            if (Input.GetMouseButtonDown(0))
            {
                isFiring = true;
                StartCoroutine(FiringWeapon());
            }
        }
    }

    IEnumerator FiringWeapon()
    {
        pistolShot.Play();
        thePlayer.GetComponent<Animator>().Play("Fire 1Pistol");
        yield return new WaitForSeconds(fireRate);
        thePlayer.GetComponent<Animator>().Play("Aiming 1Pistol");
        isFiring = false;
    }
}
