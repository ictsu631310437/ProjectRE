using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryScreen;

    public GameObject inventoryFade;

    public AudioSource inventoryOpen;

    public bool isOpen = false;

    public AudioSource inventoryClose;

    public bool canClose = false;

    // Update is called once per frame
    void Update()
    {
        if (GlobalControl.disableInv == false) 
        {
            if (Input.GetButton("Cancel") && isOpen == false && canClose == false)
            {
                isOpen = true;
                inventoryOpen.Play();
                inventoryFade.SetActive(true);
                StartCoroutine(InvControl());
            }

            if (Input.GetButton("Cancel") && isOpen == true && canClose == true)
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                isOpen = false;
                inventoryOpen.Play();
                inventoryFade.SetActive(true);
                StartCoroutine(InvControl());
            }
        }
    }

    public void ExitButton()
        {   
            Time.timeScale = 1;
            Cursor.visible = false;
            isOpen = false;
            inventoryOpen.Play();
            inventoryFade.SetActive(true);
            StartCoroutine(InvControl());  
        }

    IEnumerator InvControl()
    {
        yield return new WaitForSeconds(0.25f);
        if (isOpen == true)
        {
            inventoryScreen.SetActive(true);
        }

        else
        {
            inventoryScreen.SetActive(false);
        }

        yield return new WaitForSeconds(0.25f);
        inventoryFade.SetActive(false);
        if (isOpen == true)
        {
            canClose = true;
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            canClose = false;
            
        }
    }
}

