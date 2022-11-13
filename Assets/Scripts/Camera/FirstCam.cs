using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstCam : MonoBehaviour
{
    public GameObject cameraOn;
    public GameObject cameraOff;
    public bool camOn = false;
    public int cameraNumber;

    // Start is called before the first frame update
        void Start()
        {
            cameraNumber = 1;

            //StartCoroutine(CameraSwitch());
        }

        //IEnumerator CameraSwitch()
        //{
        //    yield return new WaitForSeconds(5);
        //    cameraTwo.SetActive(true);
          //  cameraOne.SetActive(false);
            //camOn = true;
            //cameraNumber = 2;
        //}

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                cameraOn.SetActive(true);
                cameraOff.SetActive(false);
            }
        }

}